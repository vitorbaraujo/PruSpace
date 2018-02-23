using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// The enemy can be, imprevisible, shooter, or static
	public bool imprevisible, shooter;
	public float verticalSpeed;
	public float horizontalSpeed;

	public bool canShoot;
	public SpriteRenderer bulletSprite;
	public float bulletSpeed, shootInterval;
	public int weight;

	private int direction;

	void Start() {
		direction = (Random.Range (0, 2) == 1 ? 1 : -1);

		if (canShoot) {
			FindObjectOfType<AudioManager>().Play("ThunderShoot");
			InvokeRepeating ("Fire", 0.00001f, shootInterval);
		}
	}

	void Update () {
		Move ();
	}

	void Fire () {
		GameObject bulletShoot = Instantiate(Resources.Load ("Prefabs/Bullet"),
			gameObject.transform.position, gameObject.transform.rotation) as GameObject;

		Vector3 playerPosition = GameObject.Find ("Player").transform.position;

		Rigidbody2D rigidBody = bulletShoot.GetComponent<Rigidbody2D> ();
		rigidBody.velocity = new Vector2 (playerPosition.x, 
			(playerPosition.y > gameObject.transform.position.y ? 1f : -1f) * bulletSpeed +
			BackgroundController.verticalVelocity +	playerPosition.y);

		Destroy (bulletShoot, 4f);
	}

	void Move() {

		// Get the enemy current position
		Vector2 position = transform.position;

		// Compute the enemy new position
		position = new Vector2(position.x + horizontalSpeed  * direction * Time.deltaTime, position.y + verticalSpeed * Time.deltaTime);

		// Update the enemy position
		transform.position = position;
		//transform.position += direction * Vector3.right * horizontalSpeed * Time.deltaTime;
	}
		
	void OnTriggerEnter2D(Collider2D collision) {
		if ((collision.gameObject.CompareTag ("wall") || collision.gameObject.CompareTag ("enemy")) && !imprevisible) {
			Debug.Log("Colidiu com: " + collision.gameObject.name);
			direction *= -1;
		}
	}
}
