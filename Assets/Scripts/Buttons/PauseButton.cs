using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PauseButton : MonoBehaviour {

	//public GameObject pauseCanvas;

	void OnMouseUp() {
		PauseGame();
	}


	public void PauseGame() {
		string sceneName = SceneManager.GetActiveScene().name;
		if (sceneName == "ArcadeMode") {
			
			ArcadeMode canvasAM = GameObject.Find ("Canvas").GetComponent<ArcadeMode> ();
			canvasAM.pause = true;
			//canvasAM.panda.SetActive(false);
			foreach (GameObject item in canvasAM.items) {
					item.SetActive (false);
			}
			canvasAM.pauseCanvas.SetActive(true);
			gameObject.SetActive (false);

		} else if (sceneName == "SurvivalMode") {
			
			SurvivalMode canvasAM = GameObject.Find ("Canvas").GetComponent<SurvivalMode> ();
			canvasAM.pause = true;
			//canvasAM.panda.SetActive(false);
			foreach (GameObject item in canvasAM.items) {
					item.SetActive (false);
			}
			canvasAM.pauseCanvas.SetActive(true);
			gameObject.SetActive (false);

		}
	}


	
	// #if UNITY_ANDROID

	//     void OnApplicationFocus (bool focus) {
	//         if (!focus) {
	//         	PauseGame();
	//         }  
	//     }

 // 	#endif
 
 // 	#if UNITY_EDITOR || UNITY_IOS

	//     void OnApplicationPause (bool pause) {
	//         if (!pause){
	//         	PauseGame();
	//         }
	//     }

 // 	#endif	

}
