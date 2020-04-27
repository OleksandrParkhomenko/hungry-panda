using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject panda_default;
	

	public GameObject shopCanvas;
	public GameObject recordsCanvas;
	public GameObject chooseModeCanvas;
	public GameObject itemsShop;
	public GameObject bgShop;
	

	void Awake() {
		// setting font size in stats
		int size = GameObject.Find("TimerStateValue").GetComponent<Text> ().fontSize;
		GameObject.Find("HungyStatePercent").GetComponent<Text> ().fontSize = size;
	}


	// Use this for initialization
	void Start () {
		checkStart();
		
		setPlayerStats();

		recordsCanvas = GameObject.Find ("RecordsCanvas");
		recordsCanvas.SetActive (false); // КОСТЫЛЬ!!!!
		shopCanvas = GameObject.Find("ShopCanvas");
		shopCanvas.SetActive (false);
		chooseModeCanvas = GameObject.Find("ChooseModeCanvas");
		chooseModeCanvas.SetActive(false);

	}
	

	// Update is called once per frame
	void Update () {
		setPlayerStats();

		takeScreenShot();
		resetPlayerPrefs();

	}

	private void checkStart() {
		if (Application.isEditor == false){
			if (PlayerPrefs.GetInt ("first-start") == 0 || !PlayerPrefs.HasKey("first-start")) {
				clearPlayerPrefs();
			} 
		}
	}


	private void resetPlayerPrefs() {
		if (Application.isEditor && Input.GetKeyDown(KeyCode.AltGr)) {
			clearPlayerPrefs();
			Debug.Log("PlayerPrefs cleared");
		}
	}

	private void clearPlayerPrefs() {
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.SetInt ("first-start", 1);
		PlayerPrefs.SetInt ("coins", 15);
		PlayerPrefs.SetInt ("diamonds", 3);
		PlayerPrefs.SetString("item", "none");
		PlayerPrefs.SetString("background", "BackgroundDefault");
		PlayerPrefs.SetInt("eatenBamboo", 0);
		PlayerPrefs.SetInt("maxBamboo", 100);
		PlayerPrefs.SetFloat("hungryTime", 0.0f);

	}

	private void takeScreenShot() {
		string folderPath = System.IO.Directory.GetCurrentDirectory() + "/Screenshots/";
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (!System.IO.Directory.Exists(folderPath)) {
				System.IO.Directory.CreateDirectory(folderPath);
	 		}
	        var screenshotName = "Screenshot_" + System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".png";
	        ScreenCapture.CaptureScreenshot(System.IO.Path.Combine(folderPath, screenshotName));
	        Debug.Log(folderPath + screenshotName);
		}         
	}

	private void setPlayerStats() {
		if (PlayerPrefs.GetInt("maxBamboo") != 0) {
			string currPercent = (int)((float)PlayerPrefs.GetInt("eatenBamboo") / (float)PlayerPrefs.GetInt("maxBamboo") * 100) + "%";
			GameObject.Find("HungyStatePercent").GetComponent<Text>().text = currPercent;
		}

		float timeToDisplay = PlayerPrefs.GetFloat("hungryTime");

		float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
  		float seconds = Mathf.FloorToInt(timeToDisplay % 60);	

		GameObject.Find("TimerStateValue").GetComponent<Text> ().text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}

	private void timerUpdate() {
		//
	}
}
