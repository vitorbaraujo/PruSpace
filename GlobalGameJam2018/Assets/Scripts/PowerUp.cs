using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
	
	enum Type {speed, invincible, life};
	Type type;
	PowerUpsController controller;

	// Use this for initialization
	void Start () {
		switch (gameObject.name){
			case "SpeedPowerUp(Clone)":
				type = Type.speed;
				break;

			case "InvinciblePowerUp(Clone)":
				type = Type.invincible;
				break;

			case "LifePowerUp(Clone)":
				type = Type.life;
				break;
		}
		controller = gameObject.transform.parent.GetComponent<PowerUpsController> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// The magic number six is to decrease item speed.
		this.transform.position += new Vector3 (0, (BackgroundController.verticalVelocity + 6) * Time.deltaTime, 0);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "Player") {
			if (type == Type.invincible) {
				FindObjectOfType<AudioManager>().Play("Invincible");
				Player player = col.gameObject.GetComponent<Player> ();
//				Debug.Log ("Activate invincible");
				player.ActivateInvincible ();
			} 
			else if(type == Type.speed){
				FindObjectOfType<AudioManager>().Play("SpeedUp");
				controller.ActivateSpeedUp ();
//				Debug.Log ("Activate speed up");
			}
			else{
				FindObjectOfType<AudioManager>().Play("SpeedUp");
				controller.LifeUp ();
			}
		}
	}
}
