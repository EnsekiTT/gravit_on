using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
	public Vector3 velocity { get; private set; }

	public static Building Instantiate (Building prefab, Vector3 size){
		Building obj = Instantiate (prefab) as Building;
		obj.transform.localScale = size;
		return obj;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
