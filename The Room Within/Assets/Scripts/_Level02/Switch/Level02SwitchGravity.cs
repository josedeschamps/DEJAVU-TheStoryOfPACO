using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level02SwitchGravity : MonoBehaviour {

	public Rigidbody2D playerRB2D;
	public SpriteRenderer playerSR;
	private bool hasGravity = false;
	private Level02Manager level02Manager;


	void Start(){

		level02Manager = GameObject.FindGameObjectWithTag ("Level02Manager").GetComponent<Level02Manager> ();
	}

	void OnTriggerStay2D(Collider2D other){


		if (other.gameObject.CompareTag ("Player")) 
		{

			if (Input.GetButtonDown ("Fire1") && !hasGravity) {


				Debug.Log ("Turn off Gravity");
				playerRB2D.gravityScale = 4.0f;
				playerSR.flipY = false;



				if (level02Manager.hasNotTouch == false) {

					level02Manager.clicksToOpenDoor = 1;
					level02Manager.stopCheckingDoor = false;
					hasGravity = false;
				} 

				else 
				{
					hasGravity = true;
				}

			
			}
		}

	}


}
