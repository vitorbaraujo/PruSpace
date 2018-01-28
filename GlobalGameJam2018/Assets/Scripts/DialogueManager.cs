using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour {

	//public Text nameText;
	public TextMeshProUGUI dialogText;
	//public Text dialogText;

	public Queue<string> sentences;
	private bool isConversationStarted;

	// Use this for initialization
	void Start () {
		isConversationStarted = false;
		sentences = new Queue<string>();
	}

	public void StartDialogue (Dialogue dialogue){

		//nameText.text = dialogue.name;
		if(!isConversationStarted){
			isConversationStarted = true;
			sentences.Clear();

			foreach(string sentence in dialogue.sentences){
				sentences.Enqueue(sentence);
			}
		}
		else
			DisplayNextSentence();
	}

	public void DisplayNextSentence(){

		if(isConversationStarted){
			if(sentences.Count == 0){
			EndDialogue();
			}

			string sentence = sentences.Dequeue();
			StopAllCoroutines();
			StartCoroutine(TypeSentence(sentence));
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

	}
}
