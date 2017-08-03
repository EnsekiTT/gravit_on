using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public GameObject planet;
	public float accelerationScale;
	public Rigidbody rb;
	public float delVelocity;
	public float delLength;
	float shotVelocity;
	public Vector3 velocity { get; private set; }

	public static Bullet Instantiate (Bullet prefab, Vector3 velocity){
		Bullet obj = Instantiate (prefab) as Bullet;
		obj.velocity = velocity;
		return obj;
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = velocity;
	}
	
	// Update is called once per frame
	void Update () {
		var direction = planet.transform.position - transform.position;
		var length = direction.magnitude;
		direction.Normalize ();
		rb.AddForce (accelerationScale * direction, ForceMode.Acceleration);
		if (rb.velocity.magnitude < delVelocity) {
			GameObject.Destroy (this.gameObject);
		}
		if (length > delLength) {
			GameObject.Destroy (this.gameObject);
		}
	}
}
