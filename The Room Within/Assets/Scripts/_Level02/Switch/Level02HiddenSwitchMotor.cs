using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level02HiddenSwitchMotor : MonoBehaviour {


	private Level02Manager level02Manager;



	void Start () {

		level02Manager = GameObject.FindGameObjectWithTag ("Level02Manager").GetComponent<Level02Manager> ();

	}
		
	void OnTriggerStay2D(Collider2D other){


		if (other.gameObject.CompareTag ("Player")) 
		{

			if (Input.GetButtonDown ("Fire1") && level02Manager.hasDoorKey == false) {


				level02Manager.hasDoorKey = true;

				Debug.Log ("Has open the door");

			}
		}

	}


}
