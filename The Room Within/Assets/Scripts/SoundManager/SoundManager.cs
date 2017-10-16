using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

	private bool sceneChnge = false;
	public string homeScene = "";
	private float fadeSpeed = 0.5f;
	private AudioSource _audio;
	public float volSize;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject); // keeps the game object alive when the scene changes 
		homeScene = SceneManager.GetActiveScene().name; // gets the name of the current scene when it is first created
		_audio = GetComponent<AudioSource>(); // lookup for the AudioSource var
	}



	// add our custom OnSceneLoaded function to the SceneManager.sceneLoaded properties
	void OnEnable() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	// our custom OnSceneLoaded function
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if (homeScene != scene.name) // if the scene changed is any scene other than the scene the object was created in
			sceneChnge = true;		 // then we know a new scene was loaded and its time to start the fade out process
	}

	// Update is called once per frame
	void Update () {
		//if we are on a new scene turn down the volume on the local AudioSource
		if (sceneChnge) {
			// using a lerp to go from current volume to 0 over time, fadeSpeed can be adjusted in the inspector 
			_audio.volume = Mathf.Lerp (_audio.volume, 0, Time.deltaTime*fadeSpeed); 
			//print (audio.volume);

			if (_audio.volume < .1) // if the volume is less than .1 delete the game object. Its done.
				Destroy (gameObject);
		} else if (_audio.volume < 1) { //if the object is in its original scene and the volume is off, fade the volume in
			_audio.volume = Mathf.Lerp (_audio.volume, volSize, Time.deltaTime*fadeSpeed);
		}
	}
}
