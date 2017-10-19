using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level06SwitchMotor : MonoBehaviour {
	private Level06Manager level06Manager;
	private AudioSource switchbuttonSFX;
	private Animator switchAnim;

	void Start () {

		level06Manager = GameObject.FindGameObjectWithTag ("Level06Manager").GetComponent<Level06Manager> ();
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

			if (Input.GetButtonDown ("Fire1") && level06Manager.hasDoorKey == false)
			{


				switchbuttonSFX.Play ();
				switchAnim.SetBool ("ClickSwitch", true);
				DelaySwitchAnimation ();
				level06Manager.ClickToTake (1);

			}

		}



	}






}