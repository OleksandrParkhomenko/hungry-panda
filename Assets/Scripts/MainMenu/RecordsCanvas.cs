using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RecordsCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//GameObject.Find("RecordsText").GetComponent<Text> ().text = "YOUR RECORD IS:";

		if (PlayerPrefs.HasKey ("record")) {
			GameObject.Find("RecordsPoints").GetComponent<Text> ().text = PlayerPrefs.GetInt ("record").ToString();
		} else {
			GameObject.Find("RecordsPoints").GetComponent<Text> ().text = "0";
		}


		if (PlayerPrefs.HasKey ("record")) {
			float timeToDisplay = PlayerPrefs.GetFloat("timeRecord");

			float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
  			float seconds = Mathf.FloorToInt(timeToDisplay % 60);	

			GameObject.Find("RecordsTime").GetComponent<Text> ().text = string.Format("{0:00}:{1:00}", minutes, seconds);
		} else {
			GameObject.Find("RecordsTime").GetComponent<Text> ().text = "00:00";
		}



		//GameObject.Find("RecordsText").GetComponent<Text> ().text = toDisplay;
	}
}
