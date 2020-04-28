using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyBgButton : MonoBehaviour
{
	private Text textButton;
	private GameObject coinIcon;
	private string bgName;
	private int bgPrice;
	private int currCoins;

	public Dictionary<string, string> prices = new Dictionary<string, string>();


	void Start() {
		setPrices();

		textButton = transform.GetChild(0).gameObject.GetComponent<Text>();
		coinIcon = transform.GetChild(1).gameObject;
		bgName = transform.parent.name;
		if (bgName != "BackgroundDefault") {
			bgPrice = System.Convert.ToInt32(prices[bgName]);
		}

		checkState();
	}

	void OnMouseUp() {
		if (GetComponent<Button>().interactable) {
			handlePress();
		} else {
			GameObject info = GameObject.Find("ItemButton").GetComponent<ShopItemsButton>().info;
   			info.SetActive(true);
   			info.GetComponent<Text>().text = "Not enough coins";
   			StartCoroutine(NotEnoughCoins());	
		}
	}

	void Update() {
		
		checkState();
	}


	private void handlePress() {
		if (textButton.text == "Take off") {

			PlayerPrefs.SetString("background", "BackgroundDefault");
			//PlayerPrefs.SetInt(bgName, 0);
			textButton.text = "Use";
			coinIcon.SetActive(false);
		} else if (textButton.text == "Use"){ 
			PlayerPrefs.SetString("background", bgName);
			PlayerPrefs.SetInt(bgName, 1);
			textButton.text = "Take off";
			coinIcon.SetActive(false);
		} else if (bgName != "BackgroundDefault") {
			currCoins = PlayerPrefs.GetInt("coins");
			if (currCoins >= bgPrice) {
				PlayerPrefs.SetInt("coins", currCoins - bgPrice);
				PlayerPrefs.SetString("background", bgName);
				PlayerPrefs.SetInt(bgName, 1);
				textButton.text = "Take off";
				coinIcon.SetActive(false);
			}
		}		

	}

	private void checkState() {
		if (bgName == "BackgroundDefault") {
			textButton.text = "Default";
			coinIcon.SetActive(false);
			if (PlayerPrefs.GetString("background") == bgName) {
				GetComponent<Button>().interactable = false;
				} else {
					GetComponent<Button>().interactable = true;
				}

		} else if (PlayerPrefs.GetString("background") == bgName) {
			textButton.text = "Take off";
			coinIcon.SetActive(false);
		} else {
			if (PlayerPrefs.GetInt(bgName) == 1) {
				textButton.text = "Use";
				coinIcon.SetActive(false);
			} else {
				textButton.text = prices[bgName];
				coinIcon.SetActive(true);

				if (currCoins < bgPrice) {
					GetComponent<Button>().interactable = false;
				} else {
					GetComponent<Button>().interactable = true;
				}
			}
		}		
	}


	private void setPrices() {
		prices.Add("BackgroundChina", "20");
		prices.Add("BackgroundChinaLaterns", "25");
		prices.Add("BackgroundForest", "20");
	}


	private	IEnumerator NotEnoughCoins(){
    	GameObject info = GameObject.Find("ItemButton").GetComponent<ShopItemsButton>().info;
    	if (info.GetComponent<Text>().text == "Not enough coins") {
    		yield return new WaitForSeconds (1f);
    		info.GetComponent<Text>().text = "";
   			info.SetActive(false);
    	}
 	}
}
