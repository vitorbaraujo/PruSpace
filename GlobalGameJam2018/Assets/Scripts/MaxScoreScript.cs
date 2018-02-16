using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxScoreScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<TextMeshProUGUI>().text += "" + PlayerPrefs.GetInt("maxScore").ToString("000000");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
