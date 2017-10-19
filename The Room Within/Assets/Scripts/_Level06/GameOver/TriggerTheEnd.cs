using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTheEnd : MonoBehaviour {


	private Level06Manager level06Manager;

	void Start () {


		level06Manager = GameObject.FindGameObjectWithTag ("Level06Manager").GetComponent<Level06Manager> ();
	}
	




	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.CompareTag ("Player"))
		{


			level06Manager.LoadTheNextScene ();

		}

	}

}
