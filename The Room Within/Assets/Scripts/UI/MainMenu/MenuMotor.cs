using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuMotor : MonoBehaviour {

	public Animator fader;
	public AudioSource playsound;
	public string whatScene;



	void Start(){

		Cursor.visible = true;
	}


	void Update(){

		//just for the demo game.
		if (Input.GetButtonDown ("Fire1")) {

			StartGame ();
		}

	}


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
		SceneManager.LoadScene (whatScene);

	}



	void FadeScene(){

		StartCoroutine ("FadeNLoadScene");

	}



}
