using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuMotor : MonoBehaviour {

	public Animator fader;
	public AudioSource playsound;




	public void StartGame(){


		FadeScene ();
		playsound.Play ();



	}


	public void QuitGame(){

		Application.Quit ();

	}



	IEnumerator FadeNLoadScene(){

		yield return new WaitForSeconds (1f);
		fader.SetTrigger ("SetFader");
		yield return new WaitForSeconds (.5f);
		SceneManager.LoadScene ("_Cinematic");

	}



	void FadeScene(){

		StartCoroutine ("FadeNLoadScene");

	}



}
