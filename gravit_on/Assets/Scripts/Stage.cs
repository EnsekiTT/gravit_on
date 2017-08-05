using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour {
	public Building building;
	public Vector3 centerOfPlanet;
	public int count;
	// Use this for initialization
	void Start () {
		centerOfPlanet = new Vector3 (0f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update (){
		count--;
		if (count <= 0){
			count = 5;
			var sizeX = Random.Range (1f, 10f);
			var sizeY = Random.Range (2f, 10f);
			var sizeZ = Random.Range (1f, 10f);
			Building builds = Building.Instantiate(building, new Vector3(sizeX, sizeY, sizeZ));
			var randX = Random.Range (-1f, 1f);
			var randY = Random.Range (-1f, 1f);
			var randZ = Random.Range (-1f, 1f);
			var angle = Random.Range (-180f, 180f);
			Vector3 axis = new Vector3 (randX, randY, randZ).normalized;
			builds.transform.RotateAround (centerOfPlanet, axis, angle);
			builds.transform.position = builds.transform.up * 50 + new Vector3(0, sizeY/2 - 1, 0);
		}
	}
}
