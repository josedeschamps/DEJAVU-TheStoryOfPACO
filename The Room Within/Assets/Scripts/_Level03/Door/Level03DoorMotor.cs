using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level03DoorMotor : MonoBehaviour {


	private Level03Manager level03Manager;
	private AudioSource knockSFX;




	void Start () 
	{

		level03Manager = GameObject.FindGameObjectWithTag ("Level03Manager").GetComponent<Level03Manager> ();
		knockSFX = GetComponent<AudioSource> ();
	}


	void OnTriggerStay2D(Collider2D other){


		if (other.gameObject.CompareTag ("Player")) 
		{

			if (Input.GetButtonDown ("Fire1") && !level03Manager.hasDoorKey) {
				knockSFX.Play ();
				level03Manager.DoorKnockToTake (1);
		}

	}





		if (other.gameObject.CompareTag ("Player") && level03Manager.hasDoorKey) 
		{



			if (Input.GetButtonDown ("Fire1") && level03Manager.hasDoorKey) {


		

				level03Manager.LoadTheNextScene ();
			}



		}



}


	void OnTriggerEnter2D(Collider2D other){


		if (other.gameObject.CompareTag ("Player")  && level03Manager.hasDoorKey) {

			level03Manager.LoadTheNextScene ();
		}

	}

}

