using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneHeadSwitch : MonoBehaviour {


	private Animator boneHeadAnim;
	public AudioSource boneHeadSFX;
	private Level05Manager level05Manager;
	public ShakeMotor sm;
	public Animator doorOpen;
	public AudioSource doorOpenSFX;


	void Start () {

		level05Manager = GameObject.FindGameObjectWithTag ("Level05Manager").GetComponent<Level05Manager> ();
		boneHeadAnim = GetComponent<Animator> ();
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


		if (other.gameObject.CompareTag ("Player") && !level05Manager.hasDoorKey) {

		

			    boneHeadSFX.Play ();
			    boneHeadAnim.SetBool ("SetBoneHead", true);
				level05Manager.hasDoorKey = true;
				DelayDoor ();


		}


	}



}
