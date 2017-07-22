using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnoChick : MonoBehaviour {
	public GameObject planet;
	public float accelerationScale;
	public Rigidbody rb;
	float directionForward;
	int collisionCT = 120;
	int currentCollisionCT;
	// Use this for initialization
	void Start () {
		directionForward = 0f;
		currentCollisionCT = 0;
	}

	// Update is called once per frame
	void Update () {
		currentCollisionCT--;
		var direction = transform.position - planet.transform.position;

		direction.Normalize ();

	
		//transform.up =direction;
		transform.LookAt(planet.transform.position);
		transform.Rotate (new Vector3(-90f,0f,0f),Space.Self);
		transform.Rotate (new Vector3(0f,directionForward,0f),Space.Self);

		rb.AddForce (accelerationScale * -  direction, ForceMode.Acceleration);
		transform.position += transform.forward * 0.05f;

	}

	void OnCollisionEnter(Collision collision) {



		if (collision.gameObject.name != "planet" && currentCollisionCT <= 0) {
			currentCollisionCT = 120;
			directionForward = Random.Range (0, 360);
		}
		if (collision.gameObject.name == "Bullet(Clone)") {
			GameObject.Destroy (collision.gameObject);
		}

	}
}
