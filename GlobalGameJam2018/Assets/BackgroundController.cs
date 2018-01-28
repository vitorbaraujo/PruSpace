using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
	private float cameraTop;
	Vector3 originalPosition;

	public static float speed;

	public float offset;

	public float teste;

	public static float verticalVelocity;
	public static float multiplier;

	// Use this for initialization
	void Start () {
		float distance = Mathf.Abs (transform.position.z - Camera.main.transform.position.z);
		cameraTop = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1f, distance)).y;

		originalPosition = gameObject.transform.position + new Vector3(0, offset, 0);

		speed = -2f;
		multiplier = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		verticalVelocity = speed * multiplier;

		teste = verticalVelocity;

		float backgroundSpeed = -verticalVelocity * (1/8f);

		transform.position += new Vector3(0, Time.deltaTime * verticalVelocity, 0);

		if (transform.position.y <= cameraTop) {
			transform.position = originalPosition;
		}
	}
}
