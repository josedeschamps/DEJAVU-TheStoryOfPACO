using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Level02Manager : MonoBehaviour {


	public bool hasDoorKey, stopCheckingDoor, hasNotTouch = false;
	public int clicksToOpenDoor = 3;
	public string scene;
	public Animator faderAnim;
	public Rigidbody2D playerRB2D;
	public SpriteRenderer playerSR;



	void Update(){


		if (clicksToOpenDoor <= 0 && !stopCheckingDoor) {

			playerSR.flipY = true;
			playerRB2D.gravityScale = -4.0f;
			stopCheckingDoor = true;

		}

	}


	public void ClickToTake(int takeclicks){

		if (clicksToOpenDoor == 0) 
		{
			return;
			//clicksToOpenDoor = clicksToOpenDoor - takeclicks;

		}

		clicksToOpenDoor = clicksToOpenDoor - takeclicks;
	}


	IEnumerator StartFader(){

		yield return new WaitForSeconds (.5f);
		SceneManager.LoadScene (scene);

	}


	public void LoadTheNextScene(){


		faderAnim.SetBool ("SetFader", true);
		StartCoroutine ("StartFader");




	}



}


