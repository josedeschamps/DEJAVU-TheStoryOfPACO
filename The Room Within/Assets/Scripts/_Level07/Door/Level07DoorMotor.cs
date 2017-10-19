using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level07DoorMotor : MonoBehaviour {


	private Level07Manager level07Manager;
	private AudioSource knockSFX;




	void Start () 
	{

		level07Manager = GameObject.FindGameObjectWithTag ("Level07Manager").GetComponent<Level07Manager> ();
		knockSFX = GetComponent<AudioSource> ();
	}


	void OnTriggerStay2D(Collider2D other){


		if (other.gameObject.CompareTag ("Player")) 
		{

			if (Input.GetButtonDown ("Fire1") && !level07Manager.hasDoorKey) {
				knockSFX.Play ();
				level07Manager.DoorKnockToTake (1);
			}

		}

	}


	void OnTriggerEnter2D(Collider2D other){


		if (other.gameObject.CompareTag ("Player")  && level07Manager.hasDoorKey) {

			level07Manager.LoadTheNextScene ();
		}

	}

}