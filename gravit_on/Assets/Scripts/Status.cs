using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour {
	public Text statusText;
	public PlayerControl player;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		string status = "";
		status = status + "HP:" + player.hitPoint.ToString() + "\n";
		status = status + "Bullets :" + player.bullets.ToString () + "\n";
		statusText.text = status;
	}
}
