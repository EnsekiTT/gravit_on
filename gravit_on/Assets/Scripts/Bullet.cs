using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public GameObject planet;
	public float accelerationScale;
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		var direction = planet.transform.position - transform.position;
		direction.Normalize ();
		rb.AddForce (accelerationScale * direction, ForceMode.Acceleration);
	}
}
