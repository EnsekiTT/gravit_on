using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float elRotateSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float elRotation = Input.GetAxis ("Mouse Y") * elRotateSpeed;
		transform.Rotate (-elRotation, 0, 0);
	}
}
