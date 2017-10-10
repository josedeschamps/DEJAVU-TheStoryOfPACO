﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private Rigidbody2D rb2d;


	// Use this for initialization
	void Start () {

		rb2d = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {


		float Xpos = Input.GetAxis ("Horizontal");
		rb2d.velocity = new Vector2 (Xpos * moveSpeed, rb2d.velocity.y);
		
	}
}