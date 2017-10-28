using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnim : MonoBehaviour {


	public Animator cameraAnim;
	public PlayerController playerController;
	public Animator playerAnim;
	private bool hasKey = false;
	public BoxCollider2D playerBoundary;
	public AudioSource sceneBackgroundSFX;
	public Animator groundAnim;


	


	void DelayStoryLine(){

		StartCoroutine ("DelayLine");
	}

	IEnumerator DelayLine(){
		yield return new WaitForSeconds (3f);
		playerController.canMove = false;
		playerBoundary.enabled = true;
	}



	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.CompareTag ("Player") && !hasKey)
		{

		
			cameraAnim.SetBool ("SetCamera", true);
			sceneBackgroundSFX.Play ();
			playerController.canMove = true;
			playerAnim.SetFloat ("Speed", 0.0f);
			groundAnim.SetBool ("SetGround", true);
			DelayStoryLine ();
			hasKey = true;

			}

		}

}
