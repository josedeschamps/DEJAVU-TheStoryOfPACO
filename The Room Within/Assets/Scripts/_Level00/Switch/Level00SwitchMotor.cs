using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level00SwitchMotor : MonoBehaviour {


	private Level00Manager level00Manager;
	public bool canTouchSwitch = false;
	private Animator switchAnim;
	public Animator doorAnim;
	public ShakeMotor sm;
	private AudioSource switchbuttonSound;

	void Start () {

		level00Manager = GameObject.FindGameObjectWithTag ("Level00Manager").GetComponent<Level00Manager> ();
		switchAnim = GetComponent<Animator> ();
		switchbuttonSound = GetComponent<AudioSource> ();
	}


	void Update () {

	}




	void OnTriggerEnter2D(Collider2D other){


		if (other.gameObject.CompareTag ("Player") && canTouchSwitch) 
		{

			Debug.Log ("Strange!!!");
		}



	}


	void OnTriggerStay2D(Collider2D other){


		if (other.gameObject.CompareTag ("Player")) 
		{

			if (Input.GetButtonDown ("Fire1") && level00Manager.hasTouchSwitch ) {

				Debug.Log ("Click on Button");
				sm.ShakeCamera (.1f, 1f);
				level00Manager.hasDoorKey = true;
				doorAnim.SetBool ("OpenDoor", true);
				level00Manager.hasTouchSwitch = false;
				switchbuttonSound.Play ();
				switchAnim.SetBool ("ClickSwitch", true);


			}
		}



	}
}
