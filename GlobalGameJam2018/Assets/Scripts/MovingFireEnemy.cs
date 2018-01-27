using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingFireEnemy : MonoBehaviour {
	public float speed = 2f;
	public bool movingRight = true;
	public int countShoot = 3;
	public GameObject bullet;

	private float xmin;
	private float xmax;
	private float count;

	// Use this for initialization
	void Start () {
		float distance = Mathf.Abs (transform.position.z - Camera.main.transform.position.z);
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		
		xmin = leftMost.x;
		xmax = rightMost.x;

		count = 0f;
	}
	
	void Update () {
		if (count > countShoot) {
			GameObject bulletShoot = Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
			bulletShoot.GetComponent<Rigidbody2D>().velocity = bulletShoot.transform.forward * 6f;
			bulletShoot.transform.parent = gameObject.transform;

			Destroy(bulletShoot, 4f);
			count = 0f;
		}

		count += (float) Math.Round(Time.deltaTime, 2);
	}
}