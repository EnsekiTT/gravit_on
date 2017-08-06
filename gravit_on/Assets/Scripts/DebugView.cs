using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugView : MonoBehaviour {
	public Text fpsText;
	public Text playerPositionText;
	public Text playerLatLongAltText;
	public GameObject player;
	int frameCount;
	float prevTime;
	float fps;
	Vector3 playerPos;
	// Use this for initialization
	void Start () {
		// FPS
		frameCount = 0;
		prevTime = 0.0f;
		fps = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		fpsText.text = getFPS();
		playerPos = player.transform.position;
		playerPositionText.text = getPosition(playerPos);
		playerLatLongAltText.text = getLatLongAlt (playerPos);
	}

	string getLatLongAlt(Vector3 pos){
		var latitude = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg; //緯度
		var longitude = Mathf.Atan2(pos.x, pos.z) * Mathf.Rad2Deg;//経度
		var altitude = pos.magnitude; //高度
		string res = "Player Position Lat:" + latitude.ToString() + ", Long:" + longitude.ToString() + ", Alt:" + altitude.ToString();
		return res;
	}

	string getPosition(Vector3 pos){
		string res = "Player Position X:" + pos.x.ToString () + ", Y:" + pos.y.ToString () + ", Z:" + pos.z.ToString ();
		return res;
	}

	string getFPS(){
		++frameCount;
		float time = Time.realtimeSinceStartup - prevTime;

		if (time >= 0.5f) {
			fps = frameCount / time;
			frameCount = 0;
			prevTime = Time.realtimeSinceStartup;
		}        
		string res = "FPS: " + fps.ToString();
		return res;
	}
}
