using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class ChooseModeButton : MonoBehaviour {

	private string mode;

	void OnMouseUp() {

		mode = transform.parent.name;

		if (mode == "ArcadeSlot") {
			SceneManager.LoadScene("ArcadeMode");
			Debug.Log("Choose Arcade Mode");
		} else if (mode == "SurvivalSlot"){
			SceneManager.LoadScene("SurvivalMode");
			Debug.Log("Choose Survival Mode");
		}
		
	}

	
}
