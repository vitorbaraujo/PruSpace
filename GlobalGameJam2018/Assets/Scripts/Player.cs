using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	const int INITIAL_NUMBER_CARDS = 7;
	const float MAX_VELOCITY = 1f;

	public int cardsNumber;
	public float score;
	public Vector3 velocity;
	public float aceleration = 0.008f;
	public LevelManager levelManager;

	public GameObject cardText;
	public GameObject scoreText;

	private Sprite normalState;
	private SpriteRenderer playerSprite;
	private Shader shaderGUIText;
	private enum State{normal, invincible};
	private State state;

	// touch offset allows item not shake when it starts to move
	float deltaX;
	float deltaY;

	bool moveAllowed = false;

	Rigidbody2D rb;

	public void ActivateInvincible(){
		StopAllCoroutines ();
		StartCoroutine(InvincibleChange());
	}

	void Start () {
		playerSprite = GetComponent<SpriteRenderer>();
		shaderGUIText = Shader.Find("GUI/Text Shader");
		cardsNumber = INITIAL_NUMBER_CARDS;
		velocity = Vector3.zero;
		normalState = gameObject.GetComponent<Sprite>();
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		PlayerMovement();
		UpdateCardNumber();
		UpdateScore();

		if (cardsNumber == 0) {
			int intScore = (int) score;
			int maxScore = PlayerPrefs.GetInt("maxScore");
			PlayerPrefs.SetInt("maxScore", Mathf.Max(intScore, maxScore));
			PlayerPrefs.SetInt("currentScore", intScore);
			levelManager.LoadLevel("GameOver");
		}
	}

	void UpdateScore(){
		scoreText.GetComponent<Text>().text = score.ToString("000000");
		score += -BackgroundController.verticalVelocity;
	}



	void PlayerMovement(){

		if(Input.GetKey(KeyCode.LeftArrow)){
			//Debug.Log("Botão esquerdo pressionado");
			float xVelocity = Mathf.Clamp(velocity.x - aceleration, -MAX_VELOCITY, 0);
			velocity = new Vector3 (xVelocity, velocity.y, 0);
		}

		if(Input.GetKey(KeyCode.RightArrow)){
			float xVelocity = Mathf.Clamp(velocity.x + aceleration, 0, MAX_VELOCITY);
			velocity = new Vector3 (xVelocity, velocity.y, 0);
			//Debug.Log("Botão direito pressionado");
		}

		if(!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)){
			velocity = new Vector3(0, velocity.y, 0);
		}

		if(Input.GetKey(KeyCode.UpArrow)){
			//Debug.Log("Botão esquerdo pressionado");
			float yVelocity = Mathf.Clamp(velocity.y + aceleration, 0, MAX_VELOCITY);
			velocity = new Vector3 (velocity.x, yVelocity, 0);
		}

		if(Input.GetKey(KeyCode.DownArrow)){
			float yVelocity = Mathf.Clamp(velocity.y - aceleration, -MAX_VELOCITY, 0);
			velocity = new Vector3 (velocity.x, yVelocity, 0);
			//Debug.Log("Botão direito pressionado");
		}

		if(!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)){
			velocity = new Vector3(velocity.x, 0, 0);
		}

		gameObject.transform.position += velocity;
	}


	void OnCollisionStay2D(Collision2D col){
		if(col.gameObject.name == "HWall")
			velocity = new Vector3(0, velocity.y, 0);
		else if(col.gameObject.name == "VWall")
			velocity = new Vector3(velocity.x, 0, 0);

		//if(col.gameObject.name == "PlayerCollision")
//			Debug.Log("Colidiu com " + col.gameObject.name);
	}

	void OnTriggerEnter2D(Collider2D col){

		// Player taking damage
		if((col.gameObject.CompareTag("enemy") || col.gameObject.CompareTag("enemyBullet") ) && state == State.normal){
			FindObjectOfType<AudioManager>().Play("Hit Damage");
//			Debug.Log("Triggou com " + col.gameObject.name);
			if(col.gameObject.name == "Static Enemy(Clone)")
		        FindObjectOfType<AudioManager>().Play("DroneSound");
		      else if(col.gameObject.name == "Moving Enemy(Clone)")
				FindObjectOfType<AudioManager>().Play("OvniSound");
		      else if(col.gameObject.name == "Moving Fire Enemy(Clone)")
				FindObjectOfType<AudioManager>().Play("ThunderShoot");
			cardsNumber -= 1;
			StartCoroutine(DamageFlash());
		}else if(col.gameObject.CompareTag("powerup")){
			Destroy (col.gameObject);
		}
	}

	void NormalState() {
		gameObject.GetComponent<SpriteRenderer>().sprite = normalState;
	}

	void UpdateCardNumber(){
		cardText.GetComponent<Text>().text = cardsNumber.ToString();
	}

	IEnumerator DamageFlash(){
		state = State.invincible;
		for (int i = 0; i < 5; i++){
			playerSprite.color = Color.blue;

			yield return new WaitForSeconds(.1f);

			playerSprite.color = Color.black;

			yield return new WaitForSeconds(.1f);
		}

		playerSprite.color = Color.white;
		state = State.normal;
	}

	IEnumerator InvincibleChange(){
		state = State.invincible;
		playerSprite.color = Color.green;

		yield return new WaitForSeconds(3f);

		playerSprite.color = Color.white;
		state = State.normal;
	}
}