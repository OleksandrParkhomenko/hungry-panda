using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopBgButton : MonoBehaviour
{
	public bool shopBgOn; 

	void OnMouseUp() {

    	shopBgOn = true;
    	GameObject.Find("ItemButton").GetComponent<ShopItemsButton>().shopItemsOn = false;

    	GameObject.Find("ItemButton").GetComponent<Image>().color = new Color (0.4862745f, 0.6078432f, 0.2156863f, 1f);
		GameObject.Find("BgButton").GetComponent<Image>().color = new Color (0.627451f, 0.9019608f, 0.5058824f, 1f);

		if (string.Compare(SceneManager.GetActiveScene().name, "Main Menu") == 0)  {
			GameObject.Find("Canvas").GetComponent<MainMenu>().itemsShop.SetActive (false);	
			GameObject.Find("Canvas").GetComponent<MainMenu>().bgShop.SetActive (true);
		} else {
			GameObject.Find("Bottom").GetComponent<Bottom>().itemsShop.SetActive (false);
			GameObject.Find("Bottom").GetComponent<Bottom>().bgShop.SetActive(true);
		}
	}

}
