using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(AudioSource))]
public class VideoMotor : MonoBehaviour {
	public MovieTexture movie;
	private AudioSource sound;
	public float timer, showTextTimer;
	bool hasKey = false;
	bool clickOnce = false;
	bool hasSkip = false;

	public Animator fader;
	public Animator showText;


	void Start () {


		GetComponent<RawImage> ().texture = movie as MovieTexture;
		sound = GetComponent<AudioSource> ();
		sound.clip = movie.audioClip;
		movie.Play ();
		sound.Play ();

	}



	void Update(){

		timer -= Time.deltaTime;
		showTextTimer -= Time.deltaTime;
		if (timer < 0 && !hasKey) {
			showText.SetBool ("ShowText", false);
			FadeScene ();
			hasKey = true;

		}


		if (showTextTimer < 0 && !hasSkip) {

			showText.SetBool ("ShowText", true);
			hasSkip= true;
		}



		if(Input.GetButtonDown("Fire1") && !clickOnce){

			FadeScene();
			clickOnce = true;

		}
			

	}

	IEnumerator FadeNLoadScene(){

		yield return new WaitForSeconds (.5f);
		fader.SetTrigger ("SetFader");
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene ("_Level00");

	}



	void FadeScene(){

		StartCoroutine ("FadeNLoadScene");

	}



}
