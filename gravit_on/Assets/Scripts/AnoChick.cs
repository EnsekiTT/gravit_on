using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnoChick : MonoBehaviour {
	public GameObject planet;
	public float accelerationScale;
	public float movementSpeed;
	public Rigidbody rb;
	float directionForward;
	int collisionCT = 60;
	int currentCollisionCT;
	// Use this for initialization
	void Start () {
		directionForward = 0f;
		currentCollisionCT = collisionCT;

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
		currentCollisionCT--;

		// 重力方向を頭にして立つ
		var gravityUp = (transform.position - planet.transform.position).normalized;
		var targetVector = transform.position + transform.forward;
		transform.up = gravityUp;
		targetVector = transform.InverseTransformPoint (targetVector);
		targetVector.y = 0;
		targetVector = transform.TransformPoint (targetVector);
		transform.LookAt (targetVector, gravityUp);

		// 動き回るところ
		var moveDirection = new Vector3(0, 0, 1).normalized;
		var movePosition = transform.TransformDirection (moveDirection * movementSpeed);
		GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + movePosition);

		// 重力を出すところ
		transform.GetComponent<Rigidbody>().AddForce(gravityUp * -1 * accelerationScale);

	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name != "Stage" && currentCollisionCT <= 0) {
			currentCollisionCT = collisionCT;
			directionForward = Random.Range (0, 360);
			var azRotation = directionForward;
			transform.Rotate(0, azRotation, 0);
		}
		if (collision.gameObject.name == "Bullet(Clone)") {
			GameObject.Destroy (collision.gameObject);
		}

	}
}
