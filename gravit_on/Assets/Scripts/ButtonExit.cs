using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExit : MonoBehaviour {

	public void OnClick(){
		Debug.Log ("Exit button is clicked!");
		Application.Quit ();
	}

}
