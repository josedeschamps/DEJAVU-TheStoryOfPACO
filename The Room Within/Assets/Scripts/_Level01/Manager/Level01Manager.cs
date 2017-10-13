using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Manager : MonoBehaviour {


	public bool hasDoorKey = false;
	public int clicksToOpenDoor = 2;
	public string scene;
	public Animator faderAnim;



	void Update(){


		if (clicksToOpenDoor <= 0) {
			
			hasDoorKey = true;

		}

	}


	public void ClickToTake(int takeclicks){

		if (clicksToOpenDoor <= 0) {

			clicksToOpenDoor = clicksToOpenDoor - takeclicks;
			return;
		}

		clicksToOpenDoor = clicksToOpenDoor - takeclicks;
	}


	IEnumerator StartFader(){
		yield return new WaitForSeconds (1f);
		faderAnim.SetBool ("SetFader", true);
		yield return new WaitForSeconds (.5f);
		SceneManager.LoadScene (scene);

	}


	public void LoadTheNextScene(){


		faderAnim.SetBool ("SetFader", true);
		StartCoroutine ("StartFader");




	}



}
