using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public int cardsNumber;
	const int INITIAL_NUMBER_CARDS = 3;
	const int MAX_VELOCITY = 4;
	public Vector3 velocity;
	public float aceleration = 0.04f;
	GameObject cardText;

	// Use this for initialization
	void Start () {
		cardsNumber = INITIAL_NUMBER_CARDS;
		velocity = Vector3.zero;
		cardText = GameObject.Find("NumberCards");
	}

	// Update is called once per frame
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

	}

	void UpdateCardNumber(){
		cardText.GetComponent<Text>().text = cardsNumber.ToString();
	}
}
