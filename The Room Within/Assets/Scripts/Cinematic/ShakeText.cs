using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShakeText : MonoBehaviour {


	public float timer;

	public ShakeMotor sm;
	public Animator fader;
	bool timerReset = false;

	void Start () {


		sm.ShakeCamera (.3f, 1f);
		
	}
	

	void Update () {



		timer -= Time.deltaTime;

		if (timer < 0 && !timerReset) {

			FadeScene ();
			timerReset = true;

		}





		
		
	}



	IEnumerator FadeNLoadScene(){

		yield return new WaitForSeconds (1f);
		fader.SetTrigger ("SetFader");
		yield return new WaitForSeconds (.5f);
		SceneManager.LoadScene ("_Level00");

	}



	void FadeScene(){

		StartCoroutine ("FadeNLoadScene");

	}


}
