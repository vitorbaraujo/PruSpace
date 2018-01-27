using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed;

	public bool canShoot;
	public SpriteRenderer bulletSprite;
	public float bulletSpeed, shootInterval;
	public int weight;

	private int direction = 1;

	void Update () {
		if (speed > 0) {
			Move ();
		}
	}

	void Move() {
		transform.position += direction * Vector3.right * speed * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D collision) {
	//	print("Colidiu com " + collision.gameObject.name);
		if (collision.gameObject.CompareTag ("wall") || collision.gameObject.CompareTag ("enemy")) {
			direction *= -1;
		}

	}

//	void OnCollisionEnter2D(Collision2D collision) {
//		//print("Colidiu com " + collision.gameObject.name);
//		if (collision.gameObject.CompareTag ("wall") || collision.gameObject.CompareTag ("enemy")) {
//			direction *= -1;
//		}
//	}
}
