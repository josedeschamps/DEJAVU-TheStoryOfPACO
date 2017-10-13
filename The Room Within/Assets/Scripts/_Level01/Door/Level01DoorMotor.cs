using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01DoorMotor : MonoBehaviour {

	private Level01Manager level01Manager;




	void Start () 
	{

		level01Manager = GameObject.FindGameObjectWithTag ("Level01Manager").GetComponent<Level01Manager> ();

	}





	void OnTriggerEnter2D(Collider2D other)
	{


		if (other.gameObject.CompareTag ("Player") && level01Manager.hasDoorKey) 
		{

			Debug.Log ("Door Lock, load next scene");
			level01Manager.LoadTheNextScene ();
		}

	}
}

