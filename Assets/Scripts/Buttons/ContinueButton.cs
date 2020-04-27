using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour {

	void OnMouseUp() {
		GameObject.Find ("PauseCanvas").SetActive (false);

		string sceneName = SceneManager.GetActiveScene().name;
		if (sceneName == "ArcadeMode") {
			
			ArcadeMode canvasAM = GameObject.Find ("Canvas").GetComponent<ArcadeMode> ();
			canvasAM.pause = false;
			canvasAM.pauseButton.SetActive(true);
			canvasAM.panda.SetActive(true);
			foreach (GameObject item in canvasAM.items) {
				item.SetActive (true);
			}

		} else if (sceneName == "SurvivalMode") {
			
			SurvivalMode canvasAM = GameObject.Find ("Canvas").GetComponent<SurvivalMode> ();
			canvasAM.pause = false;
			canvasAM.pauseButton.SetActive(true);
			canvasAM.panda.SetActive(true);
			foreach (GameObject item in canvasAM.items) {
				item.SetActive (true);
			}

		}


	}
}
