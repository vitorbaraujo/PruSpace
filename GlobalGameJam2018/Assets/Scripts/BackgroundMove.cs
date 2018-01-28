using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour {

	public static float speed;
	Vector2 offset;

	public static float verticalVelocity;
	public static float multiplier;

	// Use this for initialization
	void Start () {
		speed = -2f;
		multiplier = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		verticalVelocity = speed * multiplier;

		float backgroundSpeed = -verticalVelocity * (1/8f);
		offset = new Vector2 (0, Time.time * backgroundSpeed);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;
	}
}
