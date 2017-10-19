using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level05SwitchMotor : MonoBehaviour {


	private Level05Manager level05Manager;
	private AudioSource switchbuttonSFX;
	private Animator switchAnim;

	void Start () {

		level05Manager = GameObject.FindGameObjectWithTag ("Level05Manager").GetComponent<Level05Manager> ();
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


		if (other.gameObject.CompareTag ("Player")) {

			if (Input.GetButtonDown ("Fire1") && level05Manager.hasDoorKey == false)
			{


				switchbuttonSFX.Play ();
				switchAnim.SetBool ("ClickSwitch", true);
				DelaySwitchAnimation ();
				level05Manager.ClickToTake (1);

			}

		}



	}



}
