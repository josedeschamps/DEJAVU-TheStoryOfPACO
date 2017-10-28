using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class VideoMotor : MonoBehaviour {


	public MovieTexture movie;
	public Animator fader;





	void Start () {


		GetComponent<RawImage> ().texture = movie as MovieTexture;
		movie.Play ();
		movie.loop = true;
	

	}



	void Update(){

	

		if (Input.GetButtonDown ("Fire1")) {

			StartGame ();
		}


		if (Input.GetAxis ("Horizontal") < -0.1f) {

			StartGame ();
			}

	


		if (Input.GetAxis ("Horizontal") > 0.1f) {


			StartGame ();
		}








	}


	public void StartGame(){


		FadeScene ();
	



	}




	IEnumerator FadeNLoadScene(){

		yield return new WaitForSeconds (1f);
		fader.SetTrigger ("SetFader");
		yield return new WaitForSeconds (.5f);
		SceneManager.LoadScene ("_Menu");

	}



	void FadeScene(){

		StartCoroutine ("FadeNLoadScene");

	}





}
