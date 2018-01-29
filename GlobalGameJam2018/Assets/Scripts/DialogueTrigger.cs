using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
	public bool playOnStart;

	void Start(){

		if(playOnStart){
			Debug.Log("dialogo nao eh nulo!");
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		}
	}

	public void TriggerDialogue(){
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}
}
