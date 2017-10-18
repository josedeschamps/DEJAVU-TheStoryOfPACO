using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour {

	void Awake(){

		DontDestroyOnLoad (transform.gameObject);
	}
}
