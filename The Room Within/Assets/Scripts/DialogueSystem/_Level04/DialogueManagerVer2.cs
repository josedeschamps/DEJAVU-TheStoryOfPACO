using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManagerVer2 : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
	public PlayerController playerController;
	public GameObject dialogueBox;
	public GameObject bubbles;
	bool canSkipStory = false;
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
		bubbles.SetActive (true);

	

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
