using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuControllerIntro : MonoBehaviour {

	public Animator fader;
	public float timer;
	public bool hasKey = false;
	public bool hasChange = false;





	void Update(){

	
		if (Input.GetButtonDown ("Fire1")) {

			timer = 15f;
			hasKey = false;
		}



		if(!hasKey){
		timer -= Time.deltaTime;

		}



		if (timer < 0 && !hasChange) {

			StartGame ();
			hasChange = true;
			hasKey = true;
		}

	}


	public void StartGame(){


		FadeScene ();

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

