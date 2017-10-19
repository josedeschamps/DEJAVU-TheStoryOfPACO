using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureInteractable : MonoBehaviour {




	private Level04Manager level04Manager;
	private Rigidbody2D rb2d;
	private AudioSource lucky7SFX;
	public CameraShakeMotor CSM;
	public Rigidbody2D leftPicture;
	public Rigidbody2D rightPicture;
	public Animator fadeRight;
	public Animator fadeLeft;

	void Start () {

		level04Manager = GameObject.FindGameObjectWithTag ("Level04Manager").GetComponent<Level04Manager> ();
		rb2d = GetComponent<Rigidbody2D> ();
		lucky7SFX = GetComponent<AudioSource> ();

		
	}




	void DelayFade(){

		StartCoroutine("FadeTimeDestroy");

	}

	IEnumerator FadeTimeDestroy(){
		yield return new WaitForSeconds (1f);
		Destroy (gameObject);




	}




	void OnTriggerStay2D(Collider2D other){


		if (other.gameObject.CompareTag ("Player")) 
		{

			if (Input.GetButtonDown ("Fire1") && !level04Manager.hasDoorKey) {



			
				level04Manager.turnPlatform = true;
				lucky7SFX.Play ();
				rb2d.gravityScale = 1;
				CSM.ShakeCamera (.1f, 1f);
				leftPicture.gravityScale = 1;
				rightPicture.gravityScale = 2;
				fadeRight.SetBool ("SetPicture", true);
				fadeLeft.SetBool ("SetPicture", true);
				DelayFade ();



			}
		}

	}


}
