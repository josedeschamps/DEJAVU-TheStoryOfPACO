using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreLoaderMotor : MonoBehaviour {



	private CanvasGroup fadeGroup;
	private float loadTime;
	private float minimumLogoTime = 3.0f;
	public AudioSource logoSound;
	private bool playOnce = false;

	private void Start(){


		fadeGroup = FindObjectOfType<CanvasGroup> ();

		fadeGroup.alpha = 1;



		if (Time.time < minimumLogoTime) {
			loadTime = minimumLogoTime;
		} 

		else 
		{
			loadTime = Time.time;

		}
	}




	private void Update(){

		if (Time.time < minimumLogoTime) {

			fadeGroup.alpha = 1 - Time.time;
			PlaySound ();



		}


		if (Time.time > minimumLogoTime && loadTime != 0) {

			fadeGroup.alpha = Time.time - minimumLogoTime;

			if (fadeGroup.alpha >= 1) {


				SceneManager.LoadScene ("_Menu");
			}
		}

	}



	void PlaySound(){


		if (!playOnce) {
			logoSound.Play ();
			playOnce = true;

		}
	}


}
