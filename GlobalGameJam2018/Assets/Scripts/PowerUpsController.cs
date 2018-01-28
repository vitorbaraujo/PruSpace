using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsController : MonoBehaviour {
	public PowerUp powerUp;

	public float spawnInterval = 4f;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnPowerUp", 3, spawnInterval);
	}

	void SpawnPowerUp () {
		int rand = Random.Range (0, 2);
		GameObject newPowerUp = null;

		float distance = Mathf.Abs (transform.position.z - Camera.main.transform.position.z);
		float x = Camera.main.ViewportToWorldPoint (new Vector3 (Random.Range(0.1f, 0.9f), 0, distance)).x;

		Vector3 xOffset = new Vector3(x, 0, 0);

		if (rand == 0) {
			newPowerUp = Instantiate (Resources.Load("Prefabs/SpeedPowerUp"), transform.position + xOffset, Quaternion.identity) as GameObject;
		} else {
			newPowerUp = Instantiate (Resources.Load("Prefabs/InvinciblePowerUp"), transform.position + xOffset, Quaternion.identity) as GameObject;
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
