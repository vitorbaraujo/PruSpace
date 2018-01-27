using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomDestroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log("aslkdjaksdjlk");
		Destroy (collider.gameObject);
	}

}
