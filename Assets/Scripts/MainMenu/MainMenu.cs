using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject panda_default;
	

	public GameObject shopCanvas;
	public GameObject recordsCanvas;
	public GameObject chooseModeCanvas;
	public GameObject infoCanvas;

	public GameObject itemsShop;
	public GameObject bgShop;


	void Awake() {
		// setting font size in stats
		int size = GameObject.Find("TimerStateValue").GetComponent<Text> ().fontSize;
		GameObject.Find("HungyStatePercent").GetComponent<Text> ().fontSize = size;
		if (PlayerPrefs.GetFloat("hungryTime") > 0) {
			setTimer();
		}
	}


	// Use this for initialization
	void Start () {
		checkStart();
		
		setPlayerStats();

		recordsCanvas = GameObject.Find ("RecordsCanvas");
		shopCanvas = GameObject.Find("ShopCanvas");
		chooseModeCanvas = GameObject.Find("ChooseModeCanvas");
		infoCanvas = GameObject.Find ("InfoCanvas");
		
		recordsCanvas.SetActive (false); 
		shopCanvas.SetActive (false);
		chooseModeCanvas.SetActive(false);
		infoCanvas.SetActive(false);
	}
	

	// Update is called once per frame
	void Update () {

		setPlayerStats();

		takeScreenShot();
		resetPlayerPrefs();

	}


	void OnDestroy() {
		PlayerPrefs.SetString("lastTimeEntered", System.DateTime.Now.ToString());
	}



    void OnApplicationPause(bool pauseStatus) {
    	if (pauseStatus) {
        	PlayerPrefs.SetString("lastTimeEntered", System.DateTime.Now.ToString());
    	} else {
    		setTimer();
    	}
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
		PlayerPrefs.SetFloat("maxHungryTime", 3600.0f);
		PlayerPrefs.SetFloat("hungryTime", 0.0f);
		PlayerPrefs.SetString("lastTimeEntered", System.DateTime.Now.ToString());

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

		updateHungryTimer();

		float timeToDisplay = PlayerPrefs.GetFloat("hungryTime");

		float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
  		float seconds = Mathf.FloorToInt(timeToDisplay % 60);	

		GameObject.Find("TimerStateValue").GetComponent<Text> ().text = string.Format("{0:00}:{1:00}", minutes, seconds);
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

	private void setTimer() {
		float timer = PlayerPrefs.GetFloat("hungryTime");
		string past = PlayerPrefs.GetString("lastTimeEntered");
		string now = System.DateTime.Now.ToString();
		TimeSpan diff = System.DateTime.Parse(now) - System.DateTime.Parse(past);
		PlayerPrefs.SetFloat("hungryTime", timer - (float)diff.TotalSeconds);
	}

	private void updateEatenBamboo() {
		float currTimer = PlayerPrefs.GetFloat("hungryTime");
		float timePerBamboo = PlayerPrefs.GetFloat("maxHungryTime") / PlayerPrefs.GetInt("maxBamboo");
		int eatenBamboo = (int) (currTimer / timePerBamboo) + 1;
		
		PlayerPrefs.SetInt("eatenBamboo", eatenBamboo);
	}
	
}
