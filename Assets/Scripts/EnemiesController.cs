using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour {

	private const float MINTIME = 20f;
	public float spawnInterval;
	public GameObject enemy;
	public EnemyLine enemyLine;

	public int difficult;
	public float changeDifficultInterval;
	public float maxSpawnRateInSeconds = 30f;

	private GameObject line;

	private int currentLine;
	private int idx;
	private Queue<string []> preconfsQueue;
	private int[] limits = {7, 5, 6, 5, 6, 11};

	IEnumerator IncreaseDifficult() {
		yield return new WaitForSeconds(0.001f);

		for (difficult = 1; difficult < 10; difficult++) {
			yield return new WaitForSeconds(changeDifficultInterval);
		}
	}

	void Start () {
		generateX ();
		InvokeRepeating("IncreaseSpawnRate", 0f, spawnInterval);
		InvokeRepeating ("SpawnLine", 2, spawnInterval);

		StartCoroutine(IncreaseDifficult());

		currentLine = 0;
		idx = 0;

		difficult = 1;
	}

	void Update () {
		// Changing background velocity
		BackgroundController.speed = -difficult * 0.9f;
//		print(difficult);
	}

	void SpawnEnemy() {
		// Bottom-left point of the screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));

		// Top-right point of the screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

		enemy = Instantiate (Resources.Load ("Prefabs/Meteor"), Vector2.zero, Quaternion.identity) as GameObject;

		int rand = Random.Range(1, 3);

		if(rand == 1){
			enemy.transform.position = new Vector2(min.x-1, Random.Range(min.y, max.y));
		}
		else if (rand == 2){
			enemy.transform.position = new Vector2(max.x+1, Random.Range(min.y, max.y));
			enemy.GetComponent<Enemy>().horizontalSpeed *= -1;
		}

		EnemySpawnFrequency();
	}

	void EnemySpawnFrequency(){
		float spawnInSeconds;

		if(maxSpawnRateInSeconds > MINTIME){
			spawnInSeconds = Random.Range(MINTIME, maxSpawnRateInSeconds);
		}
		else{
			spawnInSeconds = MINTIME;
		}

		Invoke("SpawnEnemy", spawnInSeconds);
	}

	void IncreaseSpawnRate(){
		if(maxSpawnRateInSeconds > MINTIME){
			maxSpawnRateInSeconds--;
		}

		else if(maxSpawnRateInSeconds == MINTIME){
			CancelInvoke("IncreaseSpawnRate");
		}


	}
		
	void SpawnLine() {
		enemyLine.preconfs = preconfsQueue.Peek();
		line = Instantiate (enemyLine.gameObject, transform.position, Quaternion.identity) as GameObject;
		line.transform.parent = this.transform;
		if (idx < 6) {
			if (++currentLine == limits [idx]) {
				currentLine = 0;
				idx++;
				if (idx < 6) {
					preconfsQueue.Dequeue ();
					BackgroundController backgroundController = GameObject.Find("BackgroundController").
																GetComponent<BackgroundController>();
					backgroundController.ActivateEndless();
				}
					
			}
		} else if (idx == 6 && spawnInterval > 0.01f) {
			if(spawnInterval != 0.01f){
				spawnInterval -= 0.005f;
			}
			CancelInvoke ("SpawnLine");
			Invoke ("SpawnLine", spawnInterval);
			Invoke ("SpawnEnemy", maxSpawnRateInSeconds);
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
