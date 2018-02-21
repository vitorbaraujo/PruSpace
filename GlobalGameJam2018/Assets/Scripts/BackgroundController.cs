using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
	private float cameraTop = 45f;
	Vector3 originalPosition;

	public static float speed;

	private float offset = 21f;

	private float teste;

	public static float verticalVelocity;
	public static float multiplier;

	// Use this for initialization
	void Start () {
		float distance = Mathf.Abs (transform.position.z - Camera.main.transform.position.z);
		//cameraTop = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1f, distance)).y;
		cameraTop = 45f;
		offset = -3.9f;

		originalPosition = gameObject.transform.position;

		speed = -2f;	
		multiplier = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		verticalVelocity = speed * multiplier;

		teste = verticalVelocity;

		transform.position += new Vector3(0, Time.deltaTime * verticalVelocity * 0.25f, 0);

		if (transform.position.y <= cameraTop) {
			transform.position = originalPosition + new Vector3(0, offset, 0);
		}
	}

	public void ActivateEndless() {
		cameraTop = 5f;
		offset = -32f;
		Instantiate(Resources.Load ("BackgroundObjects/Planets"), new Vector3 (0, 27, 5), Quaternion.identity);
	}
}
