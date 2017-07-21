using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {
	public float movementSpeed;
	public GameObject planet;
	public GameObject body;
	public float accelerationScale;
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		var direction = rb.position - planet.transform.position;
		direction.Normalize ();
		var south = 0;
		if (rb.position.y > 1) {
			south = 1;
		} else if(rb.position.y < -1) {
			south = -1;
		}
		transform.up = south * direction;
		rb.AddForce (accelerationScale * (-direction), ForceMode.Acceleration);

		if (Input.GetKey (KeyCode.W)) {
			transform.position += body.transform.forward * movementSpeed * south;
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.position -= body.transform.forward * movementSpeed * south;
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.position -= body.transform.right * movementSpeed * south;
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.position += body.transform.right * movementSpeed * south;
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			rb.velocity = south * direction * 10;
		}
	}
}
