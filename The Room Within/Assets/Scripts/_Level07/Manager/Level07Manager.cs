using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level07Manager : MonoBehaviour {
	
	public bool hasDoorKey, stopCheckingDoor = false;
	public int clicksToOpenDoor = 50;
	private bool buttonDialogue = false;
	public int doorKnocks = 2;
	public string scene;
	public Animator faderAnim;
	public Animator doorAnim;
	public AudioSource doorSFX;
	public Animator pictureAnim;
	public Rigidbody2D pictureBody;
	public AudioSource pictureSFX;
	public ShakeMotor sm;


	public GameObject bubbles;
	public GameObject dialogueBox;
	private _Level01StoryTrigger storyTrigger;


	public float standTimer;
	public bool startTimer = false;
	public bool timerAfterDialogue = false;

	void Start(){

		storyTrigger = GetComponent<_Level01StoryTrigger> ();
	}




	void Update(){

		if (startTimer && !hasDoorKey) 
		{
			standTimer -= Time.deltaTime;
		}



		if (standTimer < 0 && !hasDoorKey) 
		{

			hasDoorKey = true;
			pictureSFX.Play ();
			pictureAnim.SetBool ("SetPicture", true);
			pictureBody.gravityScale = 1;
			DelaySwitchAnimation ();


		}


		if (clicksToOpenDoor == 44 && !buttonDialogue) {

			bubbles.SetActive (true);
			dialogueBox.SetActive (true);
			storyTrigger.TriggerDialogue ();
			buttonDialogue = true;
		}

	}


	public void ClickToTake(int takeclicks){

		if (clicksToOpenDoor == 0) 
		{
			return;


		}

		clicksToOpenDoor = clicksToOpenDoor - takeclicks;
	}


	public void DoorKnockToTake(int takeknocks){

		if (doorKnocks == 0) 
		{
			return;


		}

		doorKnocks = doorKnocks - takeknocks;
	}


	void DelaySwitchAnimation(){
		StartCoroutine ("DelayAnimation");

	}

	IEnumerator DelayAnimation(){

		yield return new WaitForSeconds (1f);
		doorSFX.Play ();
		doorAnim.SetBool ("OpenDoor", true);
		sm.ShakeCamera (0.1f, 1f);
	}



	IEnumerator StartFader(){

		yield return new WaitForSeconds (.5f);
		SceneManager.LoadScene (scene);

	}


	public void LoadTheNextScene(){


		faderAnim.SetBool ("SetFader", true);
		StartCoroutine ("StartFader");




	}

}

