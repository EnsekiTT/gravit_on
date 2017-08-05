using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {
	public GameObject planet;
	public float movementSpeed;
	public float movementSpeedRun;
	public float accelerationScale;
	public float azRotateSpeed;
	public Rigidbody rb;
	private bool floorTouch;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		floorTouch = true;

		var randX = Random.Range (-1f, 1f);
		var randY = Random.Range (-1f, 1f);
		var randZ = Random.Range (-1f, 1f);
		var angle = Random.Range (-180f, 180f);
		Vector3 axis = new Vector3 (randX, randY, randZ).normalized;
		transform.RotateAround (planet.transform.position, axis, angle);
		transform.position = transform.up * (planet.transform.localScale.y/2.0f) + new Vector3(0, 2, 0);
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
		var movementSpeedGain = movementSpeed;
		if (Input.GetKey (KeyCode.LeftShift)) {
			movementSpeedGain = movementSpeedRun;
		}
		var movePosition = transform.TransformDirection (moveDirection * movementSpeedGain);
		GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + movePosition);

		// 重力を出すところ
		transform.GetComponent<Rigidbody>().AddForce(gravityUp * -1 * accelerationScale);

		// ジャンプするところ
		if (Input.GetKeyDown(KeyCode.Space) && floorTouch)
		{
			rb.velocity = gravityUp * 20;
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
