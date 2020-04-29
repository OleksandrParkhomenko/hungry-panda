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

			int currPercent = (int)((float)PlayerPrefs.GetInt("eatenBamboo") / (float)PlayerPrefs.GetInt("maxBamboo") * 100);
			if (currPercent >= 90) {
				GameObject.Find("Canvas").GetComponent<MainMenu>().infoCanvas.SetActive(true);
				GameObject.Find("Canvas").GetComponent<MainMenu>().chooseModeCanvas.SetActive (false);
				GameObject.Find("InfoCanvasText").GetComponent<InfoCanvas>().chooseMode("ArcadeMode");
			} else {
				SceneManager.LoadScene("ArcadeMode");
				Debug.Log("Choose Arcade Mode");
			}
			
		} else if (mode == "SurvivalSlot"){
			int currPercent = (int)((float)PlayerPrefs.GetInt("eatenBamboo") / (float)PlayerPrefs.GetInt("maxBamboo") * 100);
			if (currPercent <= 10) {
				GameObject.Find("Canvas").GetComponent<MainMenu>().infoCanvas.SetActive(true);
				GameObject.Find("Canvas").GetComponent<MainMenu>().chooseModeCanvas.SetActive (false);
				GameObject.Find("InfoCanvasText").GetComponent<InfoCanvas>().chooseMode("SurvivalMode");
			} else {
				SceneManager.LoadScene("SurvivalMode");
				Debug.Log("Choose Survival Mode");
			}

		}
		
	}

	
}
