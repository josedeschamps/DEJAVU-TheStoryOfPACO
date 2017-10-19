using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level07PictureMotor : MonoBehaviour {



	private Level07Manager level07Manager;
	public _Level01DialogueManager dm;
	public bool hasKey = false;



	void Start () {
		level07Manager = GameObject.FindGameObjectWithTag ("Level07Manager").GetComponent<Level07Manager> ();
	}
	




	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.CompareTag ("Player") && !level07Manager.hasDoorKey && !hasKey) {

			dm.waitForTimer = true;
			hasKey = true;
		}

	}


	void OnTriggerStay2D(Collider2D other){


		if (other.gameObject.CompareTag ("Player") && !level07Manager.hasDoorKey && !dm.waitForTimer) {

		 

			level07Manager.startTimer = true;

		
		}

	}


		void OnTriggerExit2D(Collider2D other){


		if (other.gameObject.CompareTag ("Player") && !level07Manager.hasDoorKey && !dm.waitForTimer) 
			{



				level07Manager.startTimer = false;


			}
}


}
