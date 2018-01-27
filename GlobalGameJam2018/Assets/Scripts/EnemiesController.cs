using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour {
	public GameObject enemyLine;

	private GameObject line;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnLine", 0.0001f, 2);
		// CancelInvoke();
	}

	void SpawnLine() {
		line = Instantiate (enemyLine, transform.position, Quaternion.identity) as GameObject;
		line.transform.parent = this.transform;
	}
}
