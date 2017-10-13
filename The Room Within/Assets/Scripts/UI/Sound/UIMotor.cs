using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMotor : MonoBehaviour {


	public string scene;
	public Animator faderAnim;
	public AudioSource backgroundMusic;


	public void RestartLevel(){
		faderAnim.SetBool ("SetFader", true);
		StartCoroutine ("BeginRestart");

	}




	IEnumerator BeginRestart(){


		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene (scene);
	}



	public void SoundSwitch(){



	}

}
