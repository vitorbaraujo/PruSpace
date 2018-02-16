using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YourScoreScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<TextMeshProUGUI>().text += "" + PlayerPrefs.GetInt("currentScore").ToString("000000");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
