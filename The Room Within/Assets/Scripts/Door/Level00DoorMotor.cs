using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level00DoorMotor : MonoBehaviour {

	private Level00Manager level00Manager;
	private bool tellPlayerInfo = false;




	void Start () 
	{

		level00Manager = GameObject.FindGameObjectWithTag ("Level00Manager").GetComponent<Level00Manager> ();

	}

	void OnTriggerEnter2D(Collider2D other)
	{


		if (other.gameObject.CompareTag ("Player") && level00Manager.hasDoorKey) 
		{

			Debug.Log ("Door Lock, load next scene");
		}



		if (other.gameObject.CompareTag ("Player") && !tellPlayerInfo) 
		{

			Debug.Log ("Button Animation and dialogue");
			level00Manager.hasTouchSwitch = true;
			tellPlayerInfo = true;

		}




	}
}

