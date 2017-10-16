using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginFirstStory : MonoBehaviour {



	public float timer;
	bool stopTimer = false;
	private StoryTrigger ST;
	public GameObject bubbles;
	public GameObject dialogueBox;



	void Start(){

		ST = GetComponent<StoryTrigger> ();

	}


	

	void Update () {



		timer -= Time.deltaTime;


		if (timer < 0 && !stopTimer) {

			bubbles.SetActive (true);
			dialogueBox.SetActive (true);
			ST.TriggerDialogue ();
			stopTimer = true;

		}
		
	}
}
