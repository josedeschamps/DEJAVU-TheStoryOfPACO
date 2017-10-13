using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level00Manager : MonoBehaviour {

	//level one
	public bool hasDoorKey = false;
	public bool hasTouchSwitch = false;
	public string scene;
	public Animator faderAnim;
	//level one ends here








	IEnumerator StartFader(){
		yield return new WaitForSeconds (.5f);
		SceneManager.LoadScene (scene);

	}


	public void LoadTheNextScene(){


		faderAnim.SetBool ("SetFader", true);
		StartCoroutine ("StartFader");




	}
}
