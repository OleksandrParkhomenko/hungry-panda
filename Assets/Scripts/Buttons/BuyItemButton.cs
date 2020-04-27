using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;

public class BuyItemButton : MonoBehaviour {

	private Text textButton;
	private GameObject coinIcon;
	private string itemName;
	private int itemPrice;
	private int currCoins;


	private bool pricesReady = false;
	private bool infoReady = false;
	public Dictionary<string, string> prices = new Dictionary<string, string>();
	public Dictionary<string, string> info = new Dictionary<string, string>();

	void Start() {
		setPrices();
		setInfo();

		textButton = transform.GetChild(0).gameObject.GetComponent<Text>();
		coinIcon = transform.GetChild(1).gameObject;
		itemName = transform.parent.name;
		itemPrice = Convert.ToInt32(prices[itemName]);

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


	private	IEnumerator NotEnoughCoins(){
    	GameObject info = GameObject.Find("ItemButton").GetComponent<ShopItemsButton>().info;
    	if (info.GetComponent<Text>().text == "Not enough coins") {
    		yield return new WaitForSeconds (1f);
    		info.GetComponent<Text>().text = "";
   			info.SetActive(false);
    	}
 	}

	private void handlePress() {

		if (textButton.text == "Take off") {
			PlayerPrefs.SetString("item", "none");
			//PlayerPrefs.SetInt(itemName, 0);
			textButton.text = "Equip";
			coinIcon.SetActive(false);
		} else if (textButton.text == "Equip"){ 
			PlayerPrefs.SetString("item", itemName);
			PlayerPrefs.SetInt(itemName, 1);
			textButton.text = "Take off";
			coinIcon.SetActive(false);
		} else {
			currCoins = PlayerPrefs.GetInt("coins");
			if (currCoins >= itemPrice) {
				PlayerPrefs.SetInt("coins", currCoins - itemPrice);
				PlayerPrefs.SetString("item", itemName);
				PlayerPrefs.SetInt(itemName, 1);
				textButton.text = "Take off";
				coinIcon.SetActive(false);
			}
		}		
	}

	private void setPrices() {
		prices.Add("redhardhat", "10");
		prices.Add("bluehardhat", "20");
		prices.Add("cowboyhat", "5");
		prices.Add("speedhat", "15");
		prices.Add("greenpanama", "25");
		prices.Add("whitehardhat", "30");
		prices.Add("truckethat", "20");
		pricesReady = true;
	}

	private void setInfo() {
		info.Add("redhardhat", "Save your panda once");
		info.Add("bluehardhat", "Save your panda twice");
		info.Add("cowboyhat", "Feel yourself a cowboy! Save your panda once");
		info.Add("speedhat", "Panda speed x2. Save your panda once");
		info.Add("greenpanama", "Panama? Magnetize bamboo! Save your panda once.");
		info.Add("whitehardhat", "Super hard! Save your panda 4 times");
		info.Add("truckethat", "Magnetize coins. Save your panda once.");
		infoReady = true;
	}

	private void checkState() {
		currCoins = PlayerPrefs.GetInt("coins");
		if (PlayerPrefs.GetString("item") == itemName) {
			textButton.text = "Take off";
			coinIcon.SetActive(false);
		} else {
			if (PlayerPrefs.GetInt(itemName) == 1) {
				textButton.text = "Equip";
				coinIcon.SetActive(false);
			} else {
				textButton.text = prices[itemName];
				
				coinIcon.SetActive(true);
				if (currCoins < itemPrice) {
					GetComponent<Button>().interactable = false;
				} else {
					GetComponent<Button>().interactable = true;
				}
			}
		}		
	}
}
