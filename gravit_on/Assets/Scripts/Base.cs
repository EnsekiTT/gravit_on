using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {
	public float movementSpeed;
	public GameObject planet;
	public float accelerationScale;
	public float azRotateSpeed;
	public Rigidbody rb;
	private bool floorTouch;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		floorTouch = true;
	}
	
	// Update is called once per frame
	void Update () {
		//向きを変える
		var azRotation = Input.GetAxis ("Mouse X") * azRotateSpeed;
		transform.Rotate (0, azRotation, 0);

		// 重力方向を頭にして立つ
		var gravityUp = (transform.position - planet.transform.position).normalized;
		var targetVector = transform.position + transform.forward;
		transform.up = gravityUp;
		targetVector = transform.InverseTransformPoint (targetVector);
		targetVector.y = 0;
		targetVector = transform.TransformPoint (targetVector);
		transform.LookAt (targetVector, gravityUp);

		// 動き回るところ
		var moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
		var movePosition = transform.TransformDirection (moveDirection * movementSpeed);
		GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + movePosition);

		// 重力を出すところ
		transform.GetComponent<Rigidbody>().AddForce(gravityUp * -1 * accelerationScale);

		// ジャンプするところ
		if (Input.GetKeyDown(KeyCode.Space) && floorTouch)
		{
			rb.velocity = gravityUp * 10;
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
