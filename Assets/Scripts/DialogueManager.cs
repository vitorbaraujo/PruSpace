using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

	//public Text nameText;
	public TextMeshProUGUI dialogText;
	//public Text dialogText;

	public Queue<string> sentences;
	private bool isConversationStarted;

	// Use this for initialization
	void Awake () {
		isConversationStarted = false;
		sentences = new Queue<string>();
	}

	public void StartDialogue (Dialogue dialogue){

		//nameText.text = dialogue.name;
		//Debug.Log("Dialogue:\nName: " + dialogue.name);
		if(!isConversationStarted){
			isConversationStarted = true;
			if(sentences != null)
				sentences.Clear();

			foreach(string sentence in dialogue.sentences){
				//Debug.Log("Sentence: " + sentence + "\n");
				sentences.Enqueue(sentence);
			}
			DisplayNextSentence();
		}
		else{
			DisplayNextSentence();
		}
			
	}

	public void DisplayNextSentence(){

		if(isConversationStarted){
			if(sentences.Count == 0){
				EndDialogue();
			}
			else{
				string sentence = sentences.Dequeue();
				StopAllCoroutines();
				StartCoroutine(TypeSentence(sentence));
			}
		}
	}

	IEnumerator TypeSentence (string sentence){
		dialogText.text = "";
		foreach(char letter in sentence.ToCharArray()){
			dialogText.text += letter;
			yield return null;
		}
	}

	void EndDialogue(){
		SceneManager.LoadScene("MainMenu");
	}
}
