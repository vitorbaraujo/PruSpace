using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour {
	public GameObject enemyLine;

	// Use this for initialization
	void Start () {
		// y value is not working
		GameObject line = Instantiate (enemyLine, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
		line.transform.parent = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
