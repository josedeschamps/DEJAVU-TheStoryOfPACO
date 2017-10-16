﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level03Manager : MonoBehaviour {
	public bool hasDoorKey, stopCheckingDoor = false;
	public int clicksToOpenDoor = 50;
	public int doorKnocks = 2;
	public string scene;
	public Animator faderAnim;




	void Update(){


		if (doorKnocks <= 0 && !stopCheckingDoor) {

		
			stopCheckingDoor = true;
			hasDoorKey = true;

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

