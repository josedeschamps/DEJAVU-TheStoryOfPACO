using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level04DoorMotor : MonoBehaviour {

	private Level04Manager level04Manager;
	private AudioSource knockSFX;



	void Start () 
	{

		level04Manager = GameObject.FindGameObjectWithTag ("Level04Manager").GetComponent<Level04Manager> ();
		knockSFX = GetComponent<AudioSource> ();
	}


	void OnTriggerStay2D(Collider2D other){


		if (other.gameObject.CompareTag ("Player")) {

			if (Input.GetButtonDown ("Fire1") && !level04Manager.hasDoorKey) {

				knockSFX.Play ();
				level04Manager.DoorKnockToTake (1);
			}

		}
			

	}


		void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.CompareTag ("Player") && level04Manager.hasDoorKey) {


				level04Manager.LoadTheNextScene ();
			}



		}

	}

	

