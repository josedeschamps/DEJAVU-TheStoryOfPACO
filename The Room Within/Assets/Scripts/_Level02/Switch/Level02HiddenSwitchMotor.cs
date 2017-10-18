using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level02HiddenSwitchMotor : MonoBehaviour {


	private Level02Manager level02Manager;
	public Animator doorAnim;
	private AudioSource doorSFX;
	public ShakeMotor sm;
	private Rigidbody2D rb2d;
	private Animator pictureAnim;



	void Start () {

		level02Manager = GameObject.FindGameObjectWithTag ("Level02Manager").GetComponent<Level02Manager> ();
		doorSFX = GetComponent<AudioSource> ();
		rb2d = GetComponent<Rigidbody2D> ();
		pictureAnim = GetComponent<Animator> ();
	}



	void DelayFade(){

		StartCoroutine("FadeTimeDestroy");

	}

	IEnumerator FadeTimeDestroy(){
		yield return new WaitForSeconds (3f);
		Destroy (gameObject);
	



	}
		
	void OnTriggerStay2D(Collider2D other){


		if (other.gameObject.CompareTag ("Player")) 
		{

			if (Input.GetButtonDown ("Fire1") && level02Manager.hasDoorKey == false) {


				level02Manager.hasDoorKey = true;
				sm.ShakeCamera (.1f, 1f);
				doorAnim.SetBool ("OpenDoor", true);
				doorSFX.Play ();
				rb2d.gravityScale = 1;
				pictureAnim.SetBool ("SetPicture", true);
				DelayFade ();

			

			}
		}

	}


}
