using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int cardsNumber;
	const int INITIAL_NUMBER_CARDS = 3;
	const int MAX_VELOCITY = 4;
	float velocity = 0;
	public float aceleration = 0.4f;

	// Use this for initialization
	void Start () {
		cardsNumber = INITIAL_NUMBER_CARDS;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		PlayerMovement();
	}

	void PlayerMovement(){

		gameObject.transform.position += new Vector3(0.1f * velocity, 0, 0);
		if(Input.GetKey(KeyCode.LeftArrow)){
			//Debug.Log("Botão esquerdo pressionado");
			if(velocity*-1 < MAX_VELOCITY)
				velocity -= aceleration;
			//Debug.Log("Posição do player: " + gameObject.transform.position.x);
		}
		else if(Input.GetKey(KeyCode.RightArrow)){
			if(velocity < MAX_VELOCITY)
				velocity += aceleration;
			//Debug.Log("Botão direito pressionado");
			//Debug.Log("Posição do player: " + gameObject.transform.position.x);
		}
		else{
			velocity = 0;
		}

	}

	void OnCollisionEnter2D(Collision2D col){
		//Debug.Log("Entrou no metodo de colisão");

		if(col.gameObject.name == "Enemy"){
			Debug.Log("Colidiu com a parede");
		}
	}
}
