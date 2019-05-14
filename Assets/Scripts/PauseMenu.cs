using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool gameIsPaused = false;

	public GameObject pauseMenuUI;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown((KeyCode.Escape))) {
			if(gameIsPaused) {
				Resume();
			}
			else {
				Pause();
			}
		}
	}

	public void Resume() {
		FindObjectOfType<AudioManager>().Play("Choose Option");
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		gameIsPaused = false;
	}

	void Pause() {
		FindObjectOfType<AudioManager>().Play("Pause");
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		gameIsPaused = true;
	}

	public void LoadMenu(){
		FindObjectOfType<AudioManager>().Play("Choose Option");
		Time.timeScale = 1f;
		gameIsPaused = false;
		SceneManager.LoadScene("MainMenu");
	}

	public void QuitGame(){
		FindObjectOfType<AudioManager>().Play("Choose Option");
		Application.Quit();
	}
}
