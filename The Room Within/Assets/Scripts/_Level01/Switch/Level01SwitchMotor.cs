using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01SwitchMotor : MonoBehaviour {

	private Level01Manager level01Manager;
	//public bool canTouchSwitch = false;
	private AudioSource switchbuttonSFX;
	private Animator switchAnim;

	void Start () {

		level01Manager = GameObject.FindGameObjectWithTag ("Level01Manager").GetComponent<Level01Manager> ();
		switchbuttonSFX = GetComponent<AudioSource> ();
		switchAnim = GetComponent<Animator> ();

	}


	void Update () {

	}




	void OnTriggerEnter2D(Collider2D other){


//		if (other.gameObject.CompareTag ("Player") && canTouchSwitch) 
//		{
//
//			Debug.Log ("Strange!!!");
//		}



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

			if (Input.GetButtonDown ("Fire1") && level01Manager.hasDoorKey == false) {

		
				switchbuttonSFX.Play ();
				level01Manager.ClickToTake (1);
				switchAnim.SetBool ("ClickSwitch", true);
				DelaySwitchAnimation ();


				}
			}




	}

}

