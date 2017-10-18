using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level04Manager : MonoBehaviour {
	public bool hasDoorKey, stopCheckingDoor = false;
	public int clicksToOpenDoor = 50;
	public int doorKnocks = 50;
	public int talkToBooks = 2;
	public string scene;
	public Animator faderAnim;
	public BoxCollider2D[] platformCollider;
	public bool turnPlatform = false;




	void Update(){


		if (talkToBooks <= 0 && !turnPlatform) {


			for (int i = 0; i < platformCollider.Length; i++) {

				platformCollider [i].enabled = true;

			}

			turnPlatform = true;
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

	public void BookToTake(int takeBooks){

		if (talkToBooks == 0) 
		{
			return;


		}

		talkToBooks = talkToBooks - takeBooks;
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


