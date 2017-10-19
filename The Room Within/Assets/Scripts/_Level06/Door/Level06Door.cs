using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level06Door : MonoBehaviour {
	private Level06Manager level06Manager;
	private AudioSource knockSFX;



	void Start () 
	{

		level06Manager = GameObject.FindGameObjectWithTag ("Level06Manager").GetComponent<Level06Manager> ();
		knockSFX = GetComponent<AudioSource> ();
	}


	void OnTriggerStay2D(Collider2D other){


		if (other.gameObject.CompareTag ("Player")) {

			if (Input.GetButtonDown ("Fire1") && !level06Manager.hasDoorKey) {

				knockSFX.Play ();
				level06Manager.DoorKnockToTake (1);
			}

		}


	}


	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.CompareTag ("Player") && level06Manager.hasDoorKey) {


			level06Manager.LoadTheNextScene ();
		}



	}

}

