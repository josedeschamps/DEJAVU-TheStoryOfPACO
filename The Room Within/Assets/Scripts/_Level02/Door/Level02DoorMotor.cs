using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level02DoorMotor : MonoBehaviour {



	private Level02Manager level02Manager;
	private AudioSource knockSound;




	void Start () 
	{

		level02Manager = GameObject.FindGameObjectWithTag ("Level02Manager").GetComponent<Level02Manager> ();
		knockSound = GetComponent<AudioSource> ();

	}





	void OnTriggerEnter2D(Collider2D other)
	{


		if (other.gameObject.CompareTag ("Player") && level02Manager.hasDoorKey) 
		{
			
			level02Manager.LoadTheNextScene ();
			level02Manager.hasNotTouch = true;
		}

	}



  void OnTriggerStay2D (Collider2D other)
	{


		if (other.gameObject.CompareTag ("Player")) {

			if (Input.GetButtonDown ("Fire1") && !level02Manager.hasDoorKey) {

				knockSound.Play ();

			}

		}

	}


}

			




