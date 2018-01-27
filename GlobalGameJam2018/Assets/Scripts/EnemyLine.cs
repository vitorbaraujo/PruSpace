using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLine : MonoBehaviour {
	public GameObject staticEnemy;

	private float boxSize;
	private bool[] availablePositions = new bool[6];

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 6; i++) {
			availablePositions[i] = false;
		}

		float distance = Mathf.Abs (transform.position.z - Camera.main.transform.position.z);
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));

		boxSize = (rightMost.x - leftMost.x) / 6f;

		int enemiesPerRow = Random.Range(1, 5);

		print (enemiesPerRow);
		for (int i = 0; i < enemiesPerRow; i++) {
			int randomNumber = 0;
			do {
				randomNumber = Random.Range (0, 6);
			} while(availablePositions [randomNumber] == true);

			availablePositions [randomNumber] = true;
			float randomPos = randomNumber * boxSize;
			GameObject enemy = Instantiate (staticEnemy, new Vector3 (leftMost.x + randomPos, 0, 0), Quaternion.identity) as GameObject;
			enemy.transform.parent = this.transform;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
