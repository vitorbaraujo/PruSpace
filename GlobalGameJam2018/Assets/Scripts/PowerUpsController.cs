using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsController : MonoBehaviour {
	public PowerUp powerUp;

	public float spawnInterval = 3f;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnPowerUp", 2, spawnInterval);
	}

	void SpawnPowerUp () {
		int rand = Random.Range (0, 2);
		GameObject newPowerUp = null;
		if (rand == 0) {
			newPowerUp = Instantiate (Resources.Load("Prefabs/SpeedPowerUp"), transform.position, Quaternion.identity) as GameObject;
		} else {
			newPowerUp = Instantiate (Resources.Load("Prefabs/InvinciblePowerUp"), transform.position, Quaternion.identity) as GameObject;
		}
		newPowerUp.transform.parent = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ActivateSpeedUp(){
		StopAllCoroutines();
		StartCoroutine (SpeedUp());
	}

	IEnumerator SpeedUp(){
		BackgroundController.multiplier = 2f;

		yield return new WaitForSeconds(5f);
		BackgroundController.multiplier = 1f;
	}
}
