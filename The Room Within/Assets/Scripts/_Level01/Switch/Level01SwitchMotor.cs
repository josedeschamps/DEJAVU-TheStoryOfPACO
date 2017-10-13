using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01SwitchMotor : MonoBehaviour {

	private Level01Manager level01Manager;
	//public bool canTouchSwitch = false;

	void Start () {

		level01Manager = GameObject.FindGameObjectWithTag ("Level01Manager").GetComponent<Level01Manager> ();

	}


	void Update () {

	}




	void OnTriggerEnter2D(Collider2D other){


//		if (other.gameObject.CompareTag ("Player") && canTouchSwitch) 
//		{
//
//			Debug.Log ("Strange!!!");
//		}



	}


	void OnTriggerStay2D(Collider2D other){


		if (other.gameObject.CompareTag ("Player")) 
		{

			if (Input.GetButtonDown ("Fire1") && level01Manager.hasDoorKey == false) {

		
				    Debug.Log ("Click on Button");
					level01Manager.ClickToTake (1);

				}
			}




	}

}

