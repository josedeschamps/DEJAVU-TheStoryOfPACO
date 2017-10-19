using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level07SwitchMotor : MonoBehaviour {


	public _Level01DialogueManager dm;
	private Level07Manager level07Manager;
	private AudioSource switchbuttonSFX;
	private Animator switchAnim;
	void Start () {

		level07Manager = GameObject.FindGameObjectWithTag ("Level07Manager").GetComponent<Level07Manager> ();
		switchbuttonSFX = GetComponent<AudioSource> ();
		switchAnim = GetComponent<Animator> ();
	}



	void DelaySwitchAnimation(){
		StartCoroutine ("DelayAnimation");

	}

	IEnumerator DelayAnimation(){

		yield return new WaitForSeconds (.5f);
		switchAnim.SetBool ("ClickSwitch", false);
	}


	void OnTriggerStay2D(Collider2D other){


		if (other.gameObject.CompareTag ("Player")) 
		{

			if (Input.GetButtonDown ("Fire1") && !level07Manager.hasDoorKey && !dm.waitForText) {

				switchbuttonSFX.Play ();
				switchAnim.SetBool ("ClickSwitch", true);
				DelaySwitchAnimation ();
				level07Manager.ClickToTake (1);

			}
		}

	}


}