using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level02SwitchMotor : MonoBehaviour {

	private Level02Manager level02Manager;
	private AudioSource switchbuttonSFX;
	private Animator switchAnim;


	void Start () {

		level02Manager = GameObject.FindGameObjectWithTag ("Level02Manager").GetComponent<Level02Manager> ();
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

			if (Input.GetButtonDown ("Fire1") && level02Manager.hasDoorKey == false) {


				switchbuttonSFX.Play ();
				level02Manager.ClickToTake (1);
				switchAnim.SetBool ("ClickSwitch", true);
				DelaySwitchAnimation ();
			}
		}

	}


}
	




	