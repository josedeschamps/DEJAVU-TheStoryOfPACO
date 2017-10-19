using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBoxInteractable : MonoBehaviour {


	private Animator fuseBoxAnim;
	public AudioSource fuseBoxSFX;
	private Level04Manager level04Manager;
	public ShakeMotor sm;
	public Animator doorOpen;
	public AudioSource doorOpenSFX;

	void Start () {

		fuseBoxAnim = GetComponent<Animator> ();

		level04Manager = GameObject.FindGameObjectWithTag ("Level04Manager").GetComponent<Level04Manager> ();

		
	}



	void DelayDoor(){

		StartCoroutine("DoorOpenAnimation");

	}

	IEnumerator DoorOpenAnimation(){
		yield return new WaitForSeconds (1.5f);
		sm.ShakeCamera (.1f, 1f);
		doorOpen.SetBool ("OpenDoor", true);
		doorOpenSFX.Play ();






	}




	void OnTriggerStay2D(Collider2D other){


		if (other.gameObject.CompareTag ("Player")) {

			if (Input.GetButtonDown ("Fire1") && !level04Manager.hasDoorKey) {

				fuseBoxSFX.Play ();
				fuseBoxAnim.SetBool ("SetFuseBox", true);
				level04Manager.hasDoorKey = true;
				DelayDoor ();
			}

		}


	}
	

}
