using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
	
	enum Type {speed, invincible};
	Type type;
	PowerUpsController controller;

	// Use this for initialization
	void Start () {
		type = (gameObject.name == "SpeedPowerUp(Clone)" ? Type.speed : Type.invincible);
		controller = gameObject.transform.parent.GetComponent<PowerUpsController> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.position += new Vector3 (0, BackgroundMove.verticalVelocity * Time.deltaTime, 0);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "Player") {
			if (type == Type.invincible) {
				Player player = col.gameObject.GetComponent<Player> ();
				Debug.Log ("Activate invincible");
				player.ActivateInvincible ();
			} else {
				controller.ActivateSpeedUp ();
				Debug.Log ("Activate speed up");
			}
		}
	}
}
