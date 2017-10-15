using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level04SwitchMotor : MonoBehaviour {

	private Level04Manager level04Manager;
	private ShakeMotor cameraShake;
	private DialogueTrigger DT;
	public GameObject dialogueBox;
	public BoxCollider2D[] platformCollider;
	public PlayerController playerController;


	private bool letPlayerJump = true;
	private bool letColliderTurn = true;


	void Start () {

		level04Manager = GameObject.FindGameObjectWithTag ("Level04Manager").GetComponent<Level04Manager> ();
		cameraShake = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<ShakeMotor> ();
		DT = GetComponent<DialogueTrigger> ();

	}


	void DialogueStart(){

		StartCoroutine ("ShowDialogueBox");

	}

	IEnumerator ShowDialogueBox(){

		yield return new WaitForSeconds (1.5f);
		dialogueBox.SetActive (true);
		DT.TriggerDialogue ();


	}



	void OnTriggerStay2D(Collider2D other){


		if (other.gameObject.CompareTag ("Player")) {

			if (Input.GetButtonDown ("Fire1") && level04Manager.hasDoorKey == false) {


				Debug.Log ("fake Button");
				level04Manager.ClickToTake (1);

			}

		}


		if (other.gameObject.CompareTag ("Player")) {

			if (Input.GetButtonDown ("Fire1") && letColliderTurn) {


				for (int i = 0; i < platformCollider.Length; i++) {

					platformCollider [i].enabled = true;

				}

				letColliderTurn = false;

			}

		}

	}



	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.CompareTag ("Player")) {

			if (letPlayerJump) {

				cameraShake.ShakeCamera (.2f,1f);

				DialogueStart ();
				playerController.canMove = true;
				letPlayerJump = false;

			}

		}

	}


}