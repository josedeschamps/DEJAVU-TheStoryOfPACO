using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float movementSpeed;
	public float jumpForce = 800f;
	private float jumpRate = 0.5f;
	private float nextJump = 0.0f;
	private bool  grounded;
	private Rigidbody2D rb2d;
	private Animator playerAnim;

	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float groundMeter = 0.3f;


	public bool canMove = false;
	private SpriteRenderer playerSR;
	public AudioSource playerWalkSFX;
	public AudioSource playerJumpSFX;

	void Start () {

		Cursor.visible = false;
		rb2d = GetComponent<Rigidbody2D> ();
		playerAnim = GetComponent<Animator> ();
		playerSR = GetComponent<SpriteRenderer> ();
	
		
	}
	

	void Update () {


		if (!canMove) {

			if (Input.GetButtonDown ("Jump") && grounded && Time.time > nextJump) {
				nextJump = Time.time + jumpRate;
				rb2d.AddForce (new Vector2 (0, jumpForce));
				playerJumpSFX.Play ();
			}

		}

		if (!canMove) {

			if (Input.GetAxis ("Horizontal") < -0.1f) {

				playerSR.flipX = true;
				if (!playerWalkSFX.isPlaying && grounded) {
					playerWalkSFX.Play ();
				}

			} 


			if (Input.GetAxis ("Horizontal" ) > 0.1f) {

				playerSR.flipX = false;
				if (!playerWalkSFX.isPlaying && grounded) {

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
