using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour {

	public Sound[] sounds;

	public static AudioManager instance;

	private string lastScene;
	private string lastTheme;
	//public string soundPath;

	//public string[] scenes;

	void Awake() {

		if(instance == null){
			instance = this;
		}
		else {
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);

		foreach(Sound s in sounds){
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}

		lastScene = SceneManager.GetActiveScene().name;
	}

	void Start(){
		Play("Intro");
//		lastTheme = GetComponent<AudioSource>().clip.ToString();
//		Debug.Log("Last Theme: " + lastTheme);
	}

	void Update(){
//		Debug.Log("Current Theme: " + GetComponent<AudioSource>().name);
		if(SceneManager.GetActiveScene().name != lastScene){ //&& lastTheme != GetComponent<AudioSource>().name){
			lastScene = SceneManager.GetActiveScene().name;
			Play("EarthMusic");
		}
	}

//	void OnEnable() {
//		SceneManager.sceneLoaded += doSomething;
//	}
//
//	void OnDisable() {
//		SceneManager.sceneLoaded -= doSomething;
//	}
//
//	void doSomething(Scene scene, LoadSceneMode mode) {
//		Play(soundPath);
//	}

	public void Play(string name){
//		print("NAME" + name);
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s == null){
			return;
		}
		s.isPlaying = true;
		s.source.Play();
	}
}
