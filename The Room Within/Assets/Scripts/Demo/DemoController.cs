using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoController : MonoBehaviour {


	public Animator fader;
	private int levels;



	void Update () {

//
//		//restart the level
//		if (Input.GetKeyDown (KeyCode.Alpha0)) {
//
//			RestartLevel ();
//
//		}

		//restart the whole game
		if (Input.GetKeyDown (KeyCode.Alpha9)) {

			RestartWholeGame ();

		}


		
	}



	void RestartLevel(){
		fader.SetBool ("SetFader", true);
		levels = SceneManager.GetActiveScene ().buildIndex;
		StartCoroutine ("RestartThisGame");




	}

	IEnumerator RestartThisGame(){
		yield return new WaitForSeconds (.5f);
	
		SceneManager.LoadScene (levels);

	}



	void RestartWholeGame(){
		fader.SetBool ("SetFader", true);
		StartCoroutine ("WholeGame");

	}



	IEnumerator WholeGame(){
		yield return new WaitForSeconds (.5f);
		SceneManager.LoadScene ("_Menu");

	}
}
