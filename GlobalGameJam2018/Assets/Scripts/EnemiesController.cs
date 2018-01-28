using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour {
	public float spawnInterval;
	public EnemyLine enemyLine;

	public int difficult;
	public float changeDifficultInterval;

	private GameObject line;

	private int currentLine;
	private int idx;
	private Queue<string []> preconfsQueue;
	private int[] limits = {7, 5, 6, 5, 6, 11};

	void Start () {
		generateX ();
		InvokeRepeating ("SpawnLine", 2, spawnInterval);

		changeDifficultInterval = 5f;
		InvokeRepeating ("IncreaseDifficult", 0.001f, changeDifficultInterval);
		// CancelInvoke();
		currentLine = 0;
		idx = 0;

		difficult = 1;
	}

	void Update () {
		BackgroundController.speed = -difficult * 0.9f;
	}

	void IncreaseDifficult() {
		if (difficult < 40)
			difficult++;
	}
		
	void SpawnLine() {
		enemyLine.preconfs = preconfsQueue.Peek();
		line = Instantiate (enemyLine.gameObject, transform.position, Quaternion.identity) as GameObject;
		line.transform.parent = this.transform;
		if (idx < 6) {
			if (++currentLine == limits [idx]) {
				currentLine = 0;
				idx++;
				if (idx < 6)
					preconfsQueue.Dequeue ();
			}
		} else if (idx == 6 && spawnInterval > 0.01f) {
			spawnInterval -= 0.05f;
			CancelInvoke ("SpawnLine");
			Invoke ("SpawnLine", spawnInterval);
		}

	}

	void generateX(){
		preconfsQueue = new Queue<string[]>();
		preconfsQueue.Enqueue (new string[]{ "PVVVVV", "PPVVVV", "PPPVVV", "PPPPVV", "PPPPPV" });
		preconfsQueue.Enqueue(new string[]{ "MVVV", "MM" });
		preconfsQueue.Enqueue (new string[]{ "PMVV", "PPMV", "PPPM" });
		preconfsQueue.Enqueue (new string[]{ "AVVV", "AA" });
		preconfsQueue.Enqueue (new string[]{ "PAVV", "PPAV", "PPPA" });
		preconfsQueue.Enqueue (new string[]{
			"PVVVVV", "PPVVVV", "PPPVVV", "PPPPVV", "PPPPPV",
			"PMVV", "PPMV", "PPPM", "PAVV", "PPAV", "PPPA",
			"MVVV", "MA", "AVVV", "MM", "AA"
		});
	}
}
