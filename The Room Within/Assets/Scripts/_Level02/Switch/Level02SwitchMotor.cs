﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level02SwitchMotor : MonoBehaviour {

	private Level02Manager level02Manager;


	void Start () {

		level02Manager = GameObject.FindGameObjectWithTag ("Level02Manager").GetComponent<Level02Manager> ();

	}


	void Update () {

	}




	void OnTriggerEnter2D(Collider2D other){



	}


	void OnTriggerStay2D(Collider2D other){


		if (other.gameObject.CompareTag ("Player")) 
		{

			if (Input.GetButtonDown ("Fire1") && level02Manager.hasDoorKey == false) {


				Debug.Log ("Click on Button");
				level02Manager.ClickToTake (1);

			}
		}

	}


}
	




	