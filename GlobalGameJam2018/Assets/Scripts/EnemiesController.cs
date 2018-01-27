using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour {
	public GameObject enemyLine;
	public float spawnInterval;

	private GameObject line;

	void Start () {
		InvokeRepeating ("SpawnLine", 2, spawnInterval);
		// CancelInvoke();
	}

	void SpawnLine() {
		line = Instantiate (enemyLine, transform.position, Quaternion.identity) as GameObject;
		line.transform.parent = this.transform;
	}
}
