using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour {

	

	void OnMouseUp() {
		
		if (string.Compare(SceneManager.GetActiveScene().name, "Main Menu") == 0)  {
			
			GameObject.Find("Records").GetComponent<Collider2D> ().enabled = false;
			GameObject.Find("Shop").GetComponent<Collider2D> ().enabled = false;
			GameObject.Find("Play").GetComponent<Collider2D> ().enabled = false;
			GameObject.Find("PandaMainMenu").GetComponent<Collider2D> ().enabled = false;
			
			GameObject.Find("Canvas").GetComponent<MainMenu>().shopCanvas.SetActive (true);

			GameObject.Find("Canvas").GetComponent<MainMenu>().itemsShop.SetActive (true);
			GameObject.Find("Canvas").GetComponent<MainMenu>().bgShop.SetActive (false);
			GameObject.Find("ItemButton").GetComponent<Image>().color = new Color (0.627451f, 0.9019608f, 0.5058824f, 1f);
			GameObject.Find("BgButton").GetComponent<Image>().color = new Color (0.4862745f, 0.6078432f, 0.2156863f, 1f);
		} else {
			GameObject.Find("Bottom").GetComponent<Bottom>().shopCanvas.SetActive (true);
			GameObject.Find("Bottom").GetComponent<Bottom>().loseCanvas.SetActive(false);
		}
   		
		
		GameObject info = GameObject.Find("ItemButton").GetComponent<ShopItemsButton>().info;
   		info.SetActive(false);

		

	}


	void Update() {
		if (Input.GetKeyDown(KeyCode.LeftAlt)) {
			PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 10);
			Debug.Log("You're cheater! Take your 10 coins.");
		}


		if (GameObject.Find("CoinsAmount")) {
			GameObject.Find("CoinsAmount").GetComponent<Text>().text = PlayerPrefs.GetInt("coins").ToString();
		}
	}

	
}
