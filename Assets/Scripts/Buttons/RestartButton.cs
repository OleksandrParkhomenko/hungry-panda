using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {


	void Update() {
		updateHungryTimer();
		updateEatenBamboo();
	}

	// Use this for initialization
	void OnMouseUp() {
		
		int currPercent = (int)((float)PlayerPrefs.GetInt("eatenBamboo") / (float)PlayerPrefs.GetInt("maxBamboo") * 100);
		if (currPercent >= 90 && SceneManager.GetActiveScene().name != "SurvivalMode") {
			GameObject.Find("Bottom").GetComponent<Bottom>().infoCanvas.SetActive (true);
			GameObject.Find("Bottom").GetComponent<Bottom>().loseCanvas.SetActive(false);
			GameObject.Find("InfoCanvasText").GetComponent<InfoCanvas>().chooseMode("ArcadeMode");
		} else if (currPercent <= 10 && SceneManager.GetActiveScene().name != "ArcadeMode") { 
			GameObject.Find("Bottom").GetComponent<Bottom>().infoCanvas.SetActive (true);
			GameObject.Find("Bottom").GetComponent<Bottom>().loseCanvas.SetActive(false);
			GameObject.Find("InfoCanvasText").GetComponent<InfoCanvas>().chooseMode("SurvivalMode");
		} else {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex) ;
		}

	}


	private void updateEatenBamboo() {
		float currTimer = PlayerPrefs.GetFloat("hungryTime");
		float timePerBamboo = PlayerPrefs.GetFloat("maxHungryTime") / PlayerPrefs.GetInt("maxBamboo");
		int eatenBamboo = (int) (currTimer / timePerBamboo) + 1;
		
		PlayerPrefs.SetInt("eatenBamboo", eatenBamboo);
	}

	private void updateHungryTimer(){
		float timer = PlayerPrefs.GetFloat("hungryTime");
		if (timer > 0) {
			PlayerPrefs.SetFloat("hungryTime", timer - Time.deltaTime);
			updateEatenBamboo();
		} else {
			PlayerPrefs.SetFloat("hungryTime", 0);
			PlayerPrefs.SetInt("eatenBamboo", 0);
		}

	}

}
