using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour {
	public Building building;
	public Vector3 centerOfPlanet;
	public Vector3 planetSize;
	public GameObject Builds;
	public int amount;
	// Use this for initialization
	void Start () {
		transform.localScale = planetSize;
		centerOfPlanet = transform.position;
		for( int i = 0; i < amount; i++){
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
			builds.transform.position = builds.transform.up * (planetSize.y/2.0f) + new Vector3(0, sizeY/2 - 1, 0);
			builds.transform.parent = Builds.transform;
		}

	}
	
	// Update is called once per frame
	void Update (){

	}
}
