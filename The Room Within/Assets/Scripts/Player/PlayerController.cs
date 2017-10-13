using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float movementSpeed;
	public float jumpForce = 800f;
	private bool  grounded;
	private Rigidbody2D rb2d;
	//private Animator playerAnim;

	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float groundMeter = 0.3f;


	public bool canJump = false;

	void Start () {

		rb2d = GetComponent<Rigidbody2D> ();
		//playerAnim = GetComponent<Animator> ();
		
	}
	

	void Update () {


		if (canJump) {

			if (Input.GetButtonDown ("Jump") && grounded) {

				rb2d.AddForce (new Vector2 (0, jumpForce));
			}

		}
		
	}

	void FixedUpdate(){

		//movement <--   -->
		float Xpos = Input.GetAxis ("Horizontal") * movementSpeed;
		rb2d.velocity = new Vector2 (Xpos, rb2d.velocity.y);
		//playerAnim.SetFloat ("Speed", Mathf.Abs (Xpos));
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundMeter, whatIsGround);
		//playerAnim.SetBool ("Jump", !grounded);
	}
		
}
