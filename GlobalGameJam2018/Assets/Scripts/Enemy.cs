using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	// The enemy can be, imprevisible, shooter, or static
	public bool imprevisible, shooter;
	public float verticalSpeed;
	public float horizontalSpeed;

	public bool canShoot;
	private bool isShooting;
	public SpriteRenderer bulletSprite;
	public float bulletSpeed, shootInterval;
	public int weight;

	private int direction;

	private GameObject bulletShoot;
	private Vector2 playerPosition;

	void Start() {
		isShooting = false;
		direction = (Random.Range (0, 2) == 1 ? 1 : -1);

		if (canShoot) {
			FindObjectOfType<AudioManager>().Play("ThunderShoot");
			InvokeRepeating ("Fire", 0.00001f, shootInterval);
		}
	}

	void Update () {

		if(bulletShoot != null){
			bulletShoot.transform.position = Vector2.MoveTowards(bulletShoot.transform.position, playerPosition, bulletSpeed * Time.deltaTime);

			Vector2 direction = new Vector2 (playerPosition.x - bulletShoot.transform.position.x, playerPosition.y - bulletShoot.transform.position.y);

			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

			bulletShoot.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

			if(bulletShoot.transform.position.x == playerPosition.x && bulletShoot.transform.position.y == playerPosition.y){
				Destroy (bulletShoot);
				isShooting = false;
			}
		}
		Move ();
	}

	void Fire () {
		if(isShooting != true){
			isShooting = true;
			bulletShoot = Instantiate(Resources.Load ("Prefabs/Bullet"),
			gameObject.transform.position, gameObject.transform.rotation) as GameObject;

			playerPosition = GameObject.Find ("Player").transform.position;

		/*Rigidbody2D rigidBody = bulletShoot.GetComponent<Rigidbody2D> ();
		rigidBody.velocity = new Vector2 (playerPosition.x, 
			(playerPosition.y > gameObject.transform.position.y ? 1f : -1f) * bulletSpeed +
			BackgroundController.verticalVelocity +	playerPosition.y);*/

			Destroy (bulletShoot, 2f);
		}
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
