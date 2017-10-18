using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level03SwitchMotor : MonoBehaviour {

	public _Level01DialogueManager dm;
	private Level03Manager level03Manager;
	private AudioSource switchbuttonSFX;
	private Animator switchAnim;


	void Start () {

		level03Manager = GameObject.FindGameObjectWithTag ("Level03Manager").GetComponent<Level03Manager> ();
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

			if (Input.GetButtonDown ("Fire1") && level03Manager.hasDoorKey == false && !dm.waitForText ) {

				switchbuttonSFX.Play ();
				switchAnim.SetBool ("ClickSwitch", true);
				DelaySwitchAnimation ();
				level03Manager.ClickToTake (1);

			}
		}

	}


}