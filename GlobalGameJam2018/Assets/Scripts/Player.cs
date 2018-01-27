using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public int cardsNumber;
	const int INITIAL_NUMBER_CARDS = 3;
	const float MAX_VELOCITY = 1f;
	public Vector3 velocity;
	public float aceleration = 0.008f;
	GameObject cardText;
	private Sprite normalState;
	private SpriteRenderer playerSprite;
	private Shader shaderGUIText;
	private enum State{normal, invincible};
	private State state;

	void Start () {

		playerSprite = GetComponent<SpriteRenderer>();
		shaderGUIText = Shader.Find("GUI/Text Shader");
		cardsNumber = INITIAL_NUMBER_CARDS;
		velocity = Vector3.zero;
		cardText = GameObject.Find("NumberCards");
		normalState = gameObject.GetComponent<Sprite>();
	}

	void FixedUpdate () {
		PlayerMovement();
		UpdateCardNumber();
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
		if(col.gameObject.name == "Horizontal Wall")
			velocity = new Vector3(0, velocity.y, 0);
		else if(col.gameObject.name == "Vertical Wall")
			velocity = new Vector3(velocity.x, 0, 0);

		//if(col.gameObject.name == "PlayerCollision")
			Debug.Log("Colidiu com " + col.gameObject.name);
	}

	void OnTriggerEnter2D(Collider2D col){
		if((col.gameObject.CompareTag("enemy") || col.gameObject.CompareTag("enemyBullet") ) && state == State.normal){
			Debug.Log("Triggou com " + col.gameObject.name);
			cardsNumber -= 1;
			StartCoroutine(DamageFlash());
		}
	}

	void NormalState() {
		gameObject.GetComponent<SpriteRenderer>().sprite = normalState;
	}

	void UpdateCardNumber(){
		cardText.GetComponent<Text>().text = cardsNumber.ToString();
	}

	IEnumerator DamageFlash()
    {
		state = State.invincible;
		//sCameraController.instance.ShakeCameraInTime(0.3f, 0.05f, 0.005f);
        for (int i = 0; i < 5; i++)
        {
            //playerSprite.material.shader = _shaderGUItext;
            playerSprite.color = Color.blue;

            yield return new WaitForSeconds(.1f);

            //playerSprite.material.shader = _shaderSpritesDefault;
            playerSprite.color = Color.black;

			yield return new WaitForSeconds(.1f);
        }

		playerSprite.color = Color.white;
		state = State.normal;
    }

}
