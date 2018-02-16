using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsController : MonoBehaviour {

	float leftMost;
	float rightMost;
	// Use this for initialization

	void Start () {
		StartCoroutine (CreatePlanet ());
	}
		
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator CreatePlanet(){
		yield return new WaitForSeconds(4f);
		while (true) {
			//cria
			string path = "Planets/Sprite-Planeta" + Random.Range(1, 8);
//			float randomPosition = Random.Range (0f, 1f);
			float distance = Mathf.Abs (transform.position.z - Camera.main.transform.position.z);
//			float x = Camera.main.ViewportToWorldPoint (new Vector3 (randomPosition, 0, distance)).x;
			float x = Random.Range(-2.4f, 2.2f);
			GameObject newPlanet = Instantiate (Resources.Load(path), transform.position + new Vector3(x, 0, 0), Quaternion.identity) as GameObject;

			float rand = Random.Range(3f, 10f);
			Debug.Log ("" + rand + " " + "criou");
			yield return new WaitForSeconds(rand);
		}
	}
}
