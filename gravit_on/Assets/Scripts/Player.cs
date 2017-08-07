using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;	//ネットワーク関連で必要なライブラリ

public class Player : NetworkBehaviour {
	[SerializeField]Camera FPSCharacterCam;

	// Use this for initialization
	void Start () {
		if (isLocalPlayer) {
			//FPSCharacterCamを使うため、Scene Cameraを非アクティブ化
			GameObject.Find("Scene Camera").SetActive(false);
			GetComponent<PlayerControl> ().enabled = true;
			FPSCharacterCam.enabled = true;
		}

		/*

		*/
	}
}
