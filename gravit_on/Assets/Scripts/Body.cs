using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {
	public float azRotateSpeed;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float azRotation = Input.GetAxis ("Mouse X") * azRotateSpeed;
		transform.Rotate (0, azRotation, 0);
	}
}
