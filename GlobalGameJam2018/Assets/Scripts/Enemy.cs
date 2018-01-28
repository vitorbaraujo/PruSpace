using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed;

	public bool canShoot;
	public SpriteRenderer bulletSprite;
	public float bulletSpeed, shootInterval;
	public int weight;

	private int direction;

	void Start() {
		direction = (Random.Range (0, 2) == 1 ? 1 : -1);

		if (canShoot) {
			InvokeRepeating ("Fire", 0.001f, shootInterval);
		}
	}

	void Update () {
		Move ();
	}

	//Offset
	void Fire () {
		GameObject bulletShoot = Instantiate(Resources.Load ("Prefabs/Bullet"),
			gameObject.transform.position, gameObject.transform.rotation) as GameObject;
		
		Rigidbody2D rigidBody = bulletShoot.GetComponent<Rigidbody2D> ();

		rigidBody.velocity = new Vector2(0f, -bulletSpeed + BackgroundMove.verticalVelocity);
	}

	void Move() {
		transform.position += direction * Vector3.right * speed * Time.deltaTime;
	}
		
	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag ("wall") || collision.gameObject.CompareTag ("enemy")) {
			direction *= -1;
		}
	}
}
