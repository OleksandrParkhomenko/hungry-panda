using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	float timeToDisplay = 0;

	// Use this for initialization
	void Start () {
		GetComponent<Text> ().text = "0";

	}
	
	// Update is called once per frame
	void Update () {
		SurvivalMode canvas = GameObject.Find ("Canvas").GetComponent<SurvivalMode> ();
		if (!canvas.pause && !canvas.gameOver) {
			timeToDisplay += Time.deltaTime;
		}
		canvas.timerToDisplay = timeToDisplay;

		float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
  		float seconds = Mathf.FloorToInt(timeToDisplay % 60);

		GetComponent<Text> ().text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}

	void OnDestroy() {
		PlayerPrefs.SetFloat("hungryTime", PlayerPrefs.GetFloat("hungryTime") - (float)(Mathf.FloorToInt(timeToDisplay) * 4));
	}
}
