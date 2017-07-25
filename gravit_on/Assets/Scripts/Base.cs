﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {
	public float movementSpeed;
	public GameObject planet;
	public GameObject body;
	public float accelerationScale;
	public Rigidbody rb;
	float directionForward;
	private bool floorTouch;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		directionForward = 0f;
		floorTouch = true;
	}
	
	// Update is called once per frame
	void Update () {
		var direction = transform.position - planet.transform.position;
		direction.Normalize ();

		transform.LookAt (planet.transform.position);
		transform.Rotate (new Vector3 (-90f, 0f, 0f), Space.Self);
		transform.Rotate (new Vector3 (0f, directionForward, 0f), Space.Self);

		rb.AddForce (accelerationScale * -  direction, ForceMode.Acceleration);

		if (Input.GetKey (KeyCode.W)) {
			transform.position += body.transform.forward * movementSpeed;
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.position -= body.transform.forward * movementSpeed;
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.position -= body.transform.right * movementSpeed;
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.position += body.transform.right * movementSpeed;
		}
		if (Input.GetKeyDown (KeyCode.Space) && floorTouch) {
			rb.velocity = direction * 10;
			floorTouch = false;
		}
	}

	void OnCollisionEnter(Collision collision) {
		var altitudeBase = (transform.position - planet.transform.position).magnitude;
		var altitudeCollisionObject = (collision.gameObject.transform.position - planet.transform.position).magnitude;
		if (altitudeBase > altitudeCollisionObject) {
			floorTouch = true;
		}
	}
}
