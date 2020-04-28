using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

	// Use this for initialization
	void OnMouseUp() {
		
		int currPercent = (int)((float)PlayerPrefs.GetInt("eatenBamboo") / (float)PlayerPrefs.GetInt("maxBamboo") * 100);
		if (currPercent >= 90 && SceneManager.GetActiveScene().name != "SurvivalMode") {
			GameObject.Find("Bottom").GetComponent<Bottom>().infoCanvas.SetActive (true);
			GameObject.Find("Bottom").GetComponent<Bottom>().loseCanvas.SetActive(false);
		} else {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex) ;
		}
	}

}
