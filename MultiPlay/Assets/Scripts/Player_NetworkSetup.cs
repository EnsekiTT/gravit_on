using UnityEngine;
using System.Collections;
using UnityEngine.Networking;	//ネットワーク関連で必要なライブラリー

//継承はMonoBegaviourではなくNetworkBehaviour
public class Player_NetworkSetup : NetworkBehaviour {
	//SerializeField: publicでなくてもInspector上で変数内容を指定できる
	[SerializeField]Camera FPSCharacterCam;	//FirstPersonCharacterのCamera
	[SerializeField]AudioListener audioListener;	//FirstPersonCharacterのAudio Listener

	void Start ()
	{
		//自分が操作するオブジェクトに限定する
		if (isLocalPlayer) {
			//FPSCharacterCamを使うため、Scene Cameraを非アクティブ化
			GameObject.Find("Scene Camera").SetActive(false);
			GetComponent<CharacterController>().enabled = true;	//Character Controllerをアクティブ化
			//FirstPersonControllerをアクティブ化
			GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
			//FirstPersonCharacterの各コンポーネントをアクティブ化
			FPSCharacterCam.enabled = true;
			audioListener.enabled = true;
		}
	}
}