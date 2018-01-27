using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour {
	public GameObject enemyLine;

	// Use this for initialization
	void Start () {
		// y value is not working
		for (int i = 0; i < 3; i++) {
			GameObject line = Instantiate (enemyLine, new Vector3 (0, i, 0), Quaternion.identity) as GameObject;
			line.transform.parent = this.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
