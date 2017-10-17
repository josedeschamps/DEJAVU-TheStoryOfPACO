using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float movementSpeed;
	public float jumpForce = 800f;
	private bool  grounded;
	private Rigidbody2D rb2d;
	private Animator playerAnim;

	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float groundMeter = 0.3f;


	public bool canJump, canMove = false;
	private SpriteRenderer playerSR;
	private AudioSource playerWalkSFX;

	void Start () {

		rb2d = GetComponent<Rigidbody2D> ();
		playerAnim = GetComponent<Animator> ();
		playerSR = GetComponent<SpriteRenderer> ();
		playerWalkSFX = GetComponent<AudioSource> ();
		
	}
	

	void Update () {


		if (canJump) {

			if (Input.GetButtonDown ("Jump") && grounded) {

				rb2d.AddForce (new Vector2 (0, jumpForce));
			}

		}

		if (!canMove) {

			if (Input.GetAxis ("Horizontal") < -0.1f) {

				playerSR.flipX = true;
				if (!playerWalkSFX.isPlaying) {
					playerWalkSFX.Play ();
				}

			} 


			if (Input.GetAxis ("Horizontal") > 0.1f) {

				playerSR.flipX = false;
				if (!playerWalkSFX.isPlaying) {

					playerWalkSFX.Play ();
				}

			}

		}
		
	}

	void FixedUpdate(){

		if(!canMove){
		//movement <--   -->
		float Xpos = Input.GetAxis ("Horizontal") * movementSpeed;
		rb2d.velocity = new Vector2 (Xpos, rb2d.velocity.y);
		playerAnim.SetFloat ("Speed", Mathf.Abs (Xpos));
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundMeter, whatIsGround);
		//playerAnim.SetBool ("Jump", !grounded);


		}
	}
		
}
