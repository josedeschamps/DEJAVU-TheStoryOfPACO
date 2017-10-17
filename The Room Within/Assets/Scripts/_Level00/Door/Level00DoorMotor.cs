using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level00DoorMotor : MonoBehaviour {

	private Level00Manager level00Manager;
	private DialogueManager dm;
	private bool tellPlayerInfo = false;
	public GameObject dialogueBox;
	private StoryTrigger SR;
	public GameObject Bubbles;
	private AudioSource doorOpenSFX;
	private bool playSFXOnce = false;




	void Start () 
	{
		SR = GetComponent<StoryTrigger> ();
		level00Manager = GameObject.FindGameObjectWithTag ("Level00Manager").GetComponent<Level00Manager> ();
		dm = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueManager>();
		doorOpenSFX = GetComponent<AudioSource> ();

	}


	void Update(){

		if (level00Manager.hasDoorKey && !playSFXOnce) 
		{
			DoorOpenSoundSFX ();
			playSFXOnce = true;
		}

	}




	void DoorOpenSoundSFX(){

		doorOpenSFX.Play ();

	}





	void OnTriggerEnter2D(Collider2D other)
	{


		if (other.gameObject.CompareTag ("Player") && level00Manager.hasDoorKey) 
		{

			//Debug.Log ("Door Lock, load next scene");
			level00Manager.LoadTheNextScene ();
		}



		if (other.gameObject.CompareTag ("Player") && !tellPlayerInfo) 
		{

			//Debug.Log ("Button Animation and dialogue");
			level00Manager.hasTouchSwitch = true;
			dm.switchHasAnim = true;
			dialogueBox.SetActive (true);
			Bubbles.SetActive (true);
			SR.TriggerDialogue ();
			tellPlayerInfo = true;


		

		}




	}
}

