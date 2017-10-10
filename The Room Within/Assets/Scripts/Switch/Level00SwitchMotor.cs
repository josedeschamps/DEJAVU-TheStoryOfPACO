using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level00SwitchMotor : MonoBehaviour {


	private Level00Manager level00Manager;
	public bool canTouchSwitch = false;

	void Start () {

		level00Manager = GameObject.FindGameObjectWithTag ("Level00Manager").GetComponent<Level00Manager> ();

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

			if (Input.GetButtonDown ("Jump") && level00Manager.hasTouchSwitch ) {

				Debug.Log ("Click on Button");
				level00Manager.hasDoorKey = true;
				level00Manager.hasTouchSwitch = false;
			}
		}



	}
}
