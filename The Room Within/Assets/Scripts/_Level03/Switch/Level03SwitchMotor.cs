using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level03SwitchMotor : MonoBehaviour {

	private Level03Manager level03Manager;


	void Start () {

		level03Manager = GameObject.FindGameObjectWithTag ("Level03Manager").GetComponent<Level03Manager> ();

	}



	void OnTriggerStay2D(Collider2D other){


		if (other.gameObject.CompareTag ("Player")) 
		{

			if (Input.GetButtonDown ("Fire1") && level03Manager.hasDoorKey == false) {


				Debug.Log ("fake Button");
				level03Manager.ClickToTake (1);

			}
		}

	}


}