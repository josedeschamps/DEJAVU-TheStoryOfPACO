using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Begin2ndStory : MonoBehaviour {

	public float timer;
	bool stopTimer = false;
	private _Level01StoryTrigger L01ST;
	public GameObject bubbles;
	public GameObject dialogueBox;



	void Start(){

		L01ST = GetComponent<_Level01StoryTrigger> ();

	}




	void Update () {



		timer -= Time.deltaTime;


		if (timer < 0 && !stopTimer) {

			bubbles.SetActive (true);
			dialogueBox.SetActive (true);
			L01ST.TriggerDialogue ();
			stopTimer = true;

		}

	}
}


