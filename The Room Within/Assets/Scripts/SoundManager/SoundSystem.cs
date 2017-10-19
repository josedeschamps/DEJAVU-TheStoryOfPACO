using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundSystem : MonoBehaviour {



	private bool hasCheck = false;
	void Awake(){

		DontDestroyOnLoad (transform.gameObject);
	}


	void Update(){

		if (Application.loadedLevel == 11 && !hasCheck) {


			Destroy (gameObject);
			hasCheck = true;
		}

	}
}
