using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsController : MonoBehaviour {

	public float minDistance;

	private float leftMost;
	private float rightMost;
	private Vector3 scale;
	private float xPosition;
	// Use this for initialization

	void Start () {
		StartCoroutine (CreateBackgroundObjects ());
	}
		
	// Update is called once per frame
	void Update () {
		
	}

	private string selectObject(){
		int objectOption = Random.Range(1, 3);
		string path = "";
		int objectSize = Random.Range(1, 10);

		switch(objectOption){
			case 1:
				path = "BackgroundObjects/Sprite-Planeta" + Random.Range(1, 8); // Range represents the number of the planet.
				scale = new Vector3((float)objectSize, (float)objectSize, (float)objectSize);
				xPosition = Random.Range(-2.4f, 2.2f);
				break;

			case 2:
				path = "BackgroundObjects/Sprite-Nebula" + Random.Range(1, 4);
				scale = new Vector3(1.986305f, 1.986305f, 1.986305f);
				xPosition = 0;
				break;

			case 3:
				path = "BackgroundObjects/Sprite-Estrela" + Random.Range(1, 2);
				scale = new Vector3((float)objectSize, (float)objectSize, (float)objectSize);
				xPosition = Random.Range(-2.4f, 2.2f);
				break;
		}

		Debug.Log("[selectObject] path: " + path);
		return path;
	}

	IEnumerator CreateBackgroundObjects(){
		yield return new WaitForSeconds(4f);
		while (true) {
			//cria
			string path = selectObject();
//			float randomPosition = Random.Range (0f, 1f);
//			float x = Camera.main.ViewportToWorldPoint (new Vector3 (randomPosition, 0, distance)).x;
			
			GameObject newObject = Instantiate (Resources.Load(path), transform.position + new Vector3(xPosition, 0, 0), Quaternion.identity) as GameObject;

			newObject.transform.localScale = scale;

			float rand = Random.Range(3f, 10f);
			Debug.Log ("" + rand + " " + "criou");
			yield return new WaitForSeconds(rand);
		}
	}
}
