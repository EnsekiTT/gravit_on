using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour {

	public float movementSpeed;
	public float azRotateSpeed;
	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		float azRotation = Input.GetAxis ("Mouse X") * azRotateSpeed;
		transform.Rotate (0, azRotation, 0);
		if (Input.GetKey (KeyCode.W)) {
			transform.position += transform.forward * movementSpeed;
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.position -= transform.forward * movementSpeed;
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.position -= transform.right * movementSpeed;
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.position += transform.right * movementSpeed;
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			rb.velocity = new Vector3 (0, 10, 0);
		}
	}
}
