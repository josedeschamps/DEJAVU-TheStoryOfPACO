using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {



	private _Level01StoryTrigger storyTrigger;
	public GameObject bubbles;
	public GameObject dialogueBox;
	bool onlyOnce = false;




	void Start(){


		storyTrigger = GetComponent<_Level01StoryTrigger> ();
	}


	void DelayStoryLine(){

		StartCoroutine ("DelayLine");
	}

	IEnumerator DelayLine(){
		yield return new WaitForSeconds (.1F);
		storyTrigger.TriggerDialogue ();
	}



	void OnTriggerStay2D(Collider2D other){

		if (other.gameObject.CompareTag ("Player"))
		{
			if (Input.GetButtonDown ("Fire1") && !onlyOnce) {
				dialogueBox.SetActive (true);
				bubbles.SetActive (true);
				DelayStoryLine ();
				onlyOnce = true;
			
			}
			
		}


	}
}
