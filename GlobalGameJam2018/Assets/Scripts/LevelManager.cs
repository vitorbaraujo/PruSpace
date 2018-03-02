using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		if(SceneManager.GetActiveScene().name == "GameOver"){
			DisableButton("TryAgainButton");
			DisableButton("BackButton");
		}
		SceneManager.LoadScene (name);
	}

	public void QuitRequest() {
		FindObjectOfType<AudioManager>().Play("Choose Option");
		Application.Quit ();
	}

	IEnumerator DisableButton(string button){
		GameObject.Find(button).SetActive(false);
		yield return new WaitForSeconds(1f);
		GameObject.Find(button).SetActive(true);
	}
}
