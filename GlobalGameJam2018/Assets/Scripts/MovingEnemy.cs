using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour {
	public float speed = 2f;
	public bool movingRight = true;

	private float xmin;
	private float xmax;
	// Use this for initialization
	void Start () {
		float distance = Mathf.Abs (transform.position.z - Camera.main.transform.position.z);
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));

		xmin = leftMost.x;
		xmax = rightMost.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > xmax) {
			movingRight = false;
		} else if (transform.position.x < xmin) {
			movingRight = true;
		}

		if (movingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
	}
}
