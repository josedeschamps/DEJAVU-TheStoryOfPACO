using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level03Manager : MonoBehaviour {
	public bool hasDoorKey, stopCheckingDoor = false;
	public int clicksToOpenDoor = 50;
	private bool buttonDialogue = false;
	public int doorKnocks = 2;
	public string scene;
	public Animator faderAnim;
	public Animator doorAnim;
	public ShakeMotor sm;


	public GameObject bubbles;
	public GameObject dialogueBox;
	private _Level01StoryTrigger storyTrigger;

	void Start(){

		storyTrigger = GetComponent<_Level01StoryTrigger> ();
	}


	void Update(){


		if (doorKnocks <= 0 && !stopCheckingDoor) {

		
			stopCheckingDoor = true;
			sm.ShakeCamera (.1f, 1f);
			doorAnim.SetBool ("OpenDoor", true);
			hasDoorKey = true;

		}


		if (clicksToOpenDoor == 46 && !buttonDialogue) {

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






	IEnumerator StartFader(){
		
		yield return new WaitForSeconds (.5f);
		SceneManager.LoadScene (scene);

	}


	public void LoadTheNextScene(){


		faderAnim.SetBool ("SetFader", true);
		StartCoroutine ("StartFader");




	}



}


