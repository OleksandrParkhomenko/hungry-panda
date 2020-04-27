using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyBgButton : MonoBehaviour
{
	private Text textButton;
	private GameObject coinIcon;
	private string bgName;


	void Start() {
		textButton = transform.GetChild(0).gameObject.GetComponent<Text>();
		coinIcon = transform.GetChild(1).gameObject;
		bgName = transform.parent.name;

		checkState();
	}

	void OnMouseUp() {
		if (textButton.text == "Take off") {

			PlayerPrefs.SetString("background", "BackgroundDefault");
			//PlayerPrefs.SetInt(bgName, 0);
			textButton.text = "Equip";
			coinIcon.SetActive(false);
		} else {
			PlayerPrefs.SetString("background", bgName);
			PlayerPrefs.SetInt(bgName, 1);
			if (bgName != "BackgroundDefault") {
				textButton.text = "Take off";
			}
			coinIcon.SetActive(false);
		}		
	}

	void Update() {
		
		checkState();
	}

	private void checkState() {
		if (bgName == "BackgroundDefault") {
			textButton.text = "Default";
			coinIcon.SetActive(false);
		} else if (PlayerPrefs.GetString("background") == bgName) {
			textButton.text = "Take off";
			coinIcon.SetActive(false);
		} else {
			if (PlayerPrefs.GetInt(bgName) == 1) {
				textButton.text = "Equip";
				coinIcon.SetActive(false);
			} else {
				textButton.text = "50";
				coinIcon.SetActive(true);
			}
		}		
	}
}
