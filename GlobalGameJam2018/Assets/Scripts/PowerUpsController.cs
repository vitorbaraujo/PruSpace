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
		int rand = Random.Range (0, 100);
		GameObject newPowerUp = null;

		float distance = Mathf.Abs (transform.position.z - Camera.main.transform.position.z);
		//float x = Camera.main.ViewportToWorldPoint (new Vector3 (Random.Range(0.1f, 0.9f), 0, distance)).x;
		float x = Random.Range(-2.4f, 2.2f);

		Vector3 xOffset = new Vector3(x, 0, 0);

		if (rand < 40) {
			newPowerUp = Instantiate (Resources.Load("Prefabs/SpeedPowerUp"), transform.position + xOffset, Quaternion.identity) as GameObject;
		} else if (rand >= 40 && rand < 80){
			newPowerUp = Instantiate (Resources.Load("Prefabs/InvinciblePowerUp"), transform.position + xOffset, Quaternion.identity) as GameObject;
		} else {
			newPowerUp = Instantiate (Resources.Load("Prefabs/LifePowerUp"), transform.position + xOffset, Quaternion.identity) as GameObject;
		}

		newPowerUp.transform.parent = this.transform;
	}
	
	public void LifeUp(){
		FindObjectOfType<Player>().cardsNumber++;
	}

	public void ActivateSpeedUp(){
		StopAllCoroutines();
		StartCoroutine (SpeedUp());
	}

	IEnumerator SpeedUp(){
		BackgroundController.multiplier = 2f;
		FindObjectOfType<Player>().scoreBonus = 1.2f;

		yield return new WaitForSeconds(5f);
		BackgroundController.multiplier = 1f;
		FindObjectOfType<Player>().scoreBonus = 1f;
	}
}
