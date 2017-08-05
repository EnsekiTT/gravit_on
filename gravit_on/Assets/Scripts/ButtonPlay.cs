using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour {

	public void LoadStage(){
		Debug.Log ("Play button is clicked!");
		SceneManager.LoadScene ("Main");
	}
}
