using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour {

	public Sound[] sounds;

	public static AudioManager instance;

	public string soundPath;

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
	}

	void Start()
	{
		print("Sound path" + soundPath);
		Play(soundPath);
	}

	void OnEnable() {
		SceneManager.sceneLoaded += doSomething;
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= doSomething;
	}

	void doSomething(Scene scene, LoadSceneMode mode) {
		Play(soundPath);
	}

	public void Play(string name){
//		print("NAME" + name);
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s == null){
			return;
		}
		s.source.Play();
	}
}
