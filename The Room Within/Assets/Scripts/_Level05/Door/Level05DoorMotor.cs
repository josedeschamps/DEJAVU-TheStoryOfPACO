using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level05DoorMotor : MonoBehaviour {

	private Level05Manager level05Manager;
	private AudioSource knockSFX;



	void Start () {

		level05Manager = GameObject.FindGameObjectWithTag ("Level05Manager").GetComponent<Level05Manager> ();
		knockSFX = GetComponent<AudioSource> ();
		
	}
	
	void OnTriggerStay2D(Collider2D other){


		if (other.gameObject.CompareTag ("Player")) {

			if (Input.GetButtonDown ("Fire1") && !level05Manager.hasDoorKey) {

				knockSFX.Play ();
				level05Manager.DoorKnockToTake (1);
			}

		}


	}


	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.CompareTag ("Player") && level05Manager.hasDoorKey) {


			level05Manager.LoadTheNextScene ();
		}



	}

}



