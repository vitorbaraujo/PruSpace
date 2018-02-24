using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour {

	public Sound[] sounds;

	public static AudioManager instance;

	private string lastScene;
	private string currentTheme;
	public string firstTheme;

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
		Play(firstTheme);
		currentTheme = firstTheme;
//		lastTheme = GetComponent<AudioSource>().clip.ToString();
//		Debug.Log("Last Theme: " + lastTheme);
	}

	void Update(){

		//TODO: Fazer um método que pegue o tema a partir de uma cena para ela fazer a verificação
		// 			se deve tocar a mesma música ou deve-se reproduzir outra.
//		Debug.Log("Current Theme: " + GetComponent<AudioSource>().name);
		if(SceneManager.GetActiveScene().name == "MainMenu"){
			Sound s = Array.Find(sounds, sound => sound.name == currentTheme);
			s.source.Pause();
			currentTheme = "MenuTheme";
			Play(currentTheme);
		}

		if(SceneManager.GetActiveScene().name == "Game"){
			Sound s = Array.Find(sounds, sound => sound.name == currentTheme);
			s.source.Pause();
			currentTheme = "MainTheme";
			Play(currentTheme);
		}

		/*if(SceneManager.GetActiveScene().name != lastScene && currentTheme == firstTheme){ //&& lastTheme != GetComponent<AudioSource>().name){
			lastScene = SceneManager.GetActiveScene().name;
			Sound s = Array.Find(sounds, sound => sound.name == currentTheme);
			s.source.Pause();
			Play("MainTheme");
			currentTheme = "MainTheme";
		}*/
	}

	public void Play(string name){
//		print("NAME" + name);
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s == null){
			return;
		}

		// isPlaying verifica se a música está tocando
		// TODO: tentar implementar essa parte!!
		s.isPlaying = true;
		s.source.Play();
	}
}
