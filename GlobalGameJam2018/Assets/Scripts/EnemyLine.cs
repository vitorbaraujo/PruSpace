using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLine : MonoBehaviour {
	public GameObject staticEnemy;
	public int enemiesPerRow;

	private float boxSize;
	private bool[] availablePositions = new bool[6];
	private Vector3 leftMost;
	private Vector3 rightMost;

	private float spritePadding = 0.6f;

	public string[] preconfs;

	void Start () {
		float distance = Mathf.Abs (transform.position.z - Camera.main.transform.position.z);

		leftMost = new Vector2 (-2.8f + spritePadding, 0);
		rightMost = new Vector2 (2.8f - spritePadding, 0);

		getRandom ();
	}

	void Update() {
		if (this.transform.childCount == 0) {
			Destroy (gameObject);
		}
	}

	void FixedUpdate () {
		this.transform.position += new Vector3 (0, BackgroundController.verticalVelocity * Time.deltaTime, 0);
	}

	void getRandom() {
		int idx = Random.Range (0, preconfs.Length);

		System.Random rnd = new System.Random ();
		var numbers = Enumerable.Range (0, preconfs[idx].Length).OrderBy (r => rnd.Next ()).ToArray ();

		int posInLine = 0;
		float boxSize = 4.6f / 5f;
		print (preconfs[idx]);
		for (int i = 0; i < numbers.Length; i++) {
			GameObject enemy = null;
			print ("left " + leftMost.x);
			print ("POS " + preconfs[idx][numbers [i]] + " " + (leftMost.x + posInLine * boxSize) + " " + (posInLine * boxSize));
			switch (preconfs[idx][numbers [i]]) {
			case 'V':
				posInLine += 1;
				break;
			case 'P':
				enemy = Instantiate (Resources.Load ("Prefabs/Static Enemy"), Vector3.zero, Quaternion.identity) as GameObject;
				enemy.transform.position = new Vector3(leftMost.x + posInLine * boxSize, transform.position.y, 0);
//				enemy.transform.position = new Vector3(0, transform.position.y, 0);
				posInLine += 1;
				break;
			case 'M':
				enemy = Instantiate(Resources.Load("Prefabs/Moving Enemy"), Vector3.zero, Quaternion.identity) as GameObject;
				enemy.transform.position = new Vector3(leftMost.x + posInLine * boxSize, transform.position.y, 0);
//				enemy.transform.position = new Vector3(0, transform.position.y, 0);
				posInLine += 3;
				break;
			case 'A':
				enemy = Instantiate(Resources.Load("Prefabs/Moving Fire Enemy"), Vector3.zero, Quaternion.identity) as GameObject;
				enemy.transform.position = new Vector3(leftMost.x + posInLine * boxSize, transform.position.y, 0);
				//enemy.transform.position = new Vector3(0, transform.position.y, 0);
				posInLine += 3;
				break;
			default:
				break;
			}

			if (enemy) {
				enemy.transform.parent = this.transform;
			}
		}
	}
}
