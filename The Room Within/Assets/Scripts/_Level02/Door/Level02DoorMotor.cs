using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level02DoorMotor : MonoBehaviour {



	private Level02Manager level02Manager;




	void Start () 
	{

		level02Manager = GameObject.FindGameObjectWithTag ("Level02Manager").GetComponent<Level02Manager> ();

	}





	void OnTriggerEnter2D(Collider2D other)
	{


		if (other.gameObject.CompareTag ("Player") && level02Manager.hasDoorKey) 
		{

			Debug.Log ("Door Lock, load next scene");
			level02Manager.LoadTheNextScene ();
			level02Manager.hasNotTouch = true;
		}

	}
}

