using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level04SwitchMotor : MonoBehaviour {

	private Level04Manager level04Manager;
	private AudioSource switchbuttonSFX;
	private Animator switchAnim;

	void Start () {

		level04Manager = GameObject.FindGameObjectWithTag ("Level04Manager").GetComponent<Level04Manager> ();
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

			if (Input.GetButtonDown ("Fire1") && level04Manager.hasDoorKey == false)
			{


				switchbuttonSFX.Play ();
				switchAnim.SetBool ("ClickSwitch", true);
				DelaySwitchAnimation ();
				level04Manager.ClickToTake (1);

			}

	}


	
}






}