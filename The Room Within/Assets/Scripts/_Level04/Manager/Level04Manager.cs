using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level04Manager : MonoBehaviour {
	public bool hasDoorKey, stopCheckingDoor = false;
	public int clicksToOpenDoor = 50;
	public int doorKnocks = 50;
	public string scene;
	public Animator faderAnim;
	public BoxCollider2D[] platformCollider;
	public bool turnPlatform = false;




	void Update(){


		if (turnPlatform) {


			for (int i = 0; i < platformCollider.Length; i++) {

				platformCollider [i].enabled = true;

			}

			turnPlatform = false;
		}




	}


	public void ClickToTake(int takeclicks){

		if (clicksToOpenDoor == 0) 
		{
			return;


		}

		clicksToOpenDoor = clicksToOpenDoor - takeclicks;
	}


	public void DoorKnockToTake(int takeknocks){

		if (doorKnocks == 0) 
		{
			return;


		}

		doorKnocks = doorKnocks - takeknocks;
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


