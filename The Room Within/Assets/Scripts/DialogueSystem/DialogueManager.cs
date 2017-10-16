﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
	public PlayerController playerController;
	public GameObject dialogueBox;
	bool canSkipStory = false;
	public Animator thoughtBubble;
	public GameObject bubbles;
//	public Animator dialogueAnim;


	//fi fo collection
	private Queue<string> sentences;



	void Start()
	{

		sentences = new Queue<string> ();
	}


	void Update(){


		if (canSkipStory) {


			if (Input.GetButtonDown ("Fire1")) {
				canSkipStory = false;
				DisplayNextSentence ();


			}

		}

	}


	public void StartDialogue(Dialogue dialogue)
	{

	//	dialogueAnim.SetBool ("OpenDialogue", true);
		thoughtBubble.SetBool("SetBubble",true);

	
		nameText.text = dialogue.playerName;
		sentences.Clear ();

		foreach (string sentence in dialogue.sentences) {

			sentences.Enqueue (sentence);
		}
	
		DisplayNextSentence ();

	}


	public void DisplayNextSentence(){


		if (sentences.Count == 0) {

			EndDialogue ();
			return;
		}

		string sentence = sentences.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine (TypeSentence (sentence));
		canSkipStory = true;


	}


	void EndDialogue(){

		playerController.canMove = false;
		dialogueBox.SetActive (false);
		thoughtBubble.SetBool("SetBubble",false);
		bubbles.SetActive (false);
		//dialogueAnim.SetBool ("OpenDialogue", false);
		Debug.Log("End Text");

	}



	IEnumerator TypeSentence(string sentence){
		
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()) {

			yield return new WaitForSeconds (.01f);
			dialogueText.text += letter;

			yield return null;

		}

	}





}