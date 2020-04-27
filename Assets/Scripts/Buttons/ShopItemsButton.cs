using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopItemsButton : MonoBehaviour
{
   	
	public GameObject infoBg;
	public GameObject info;

	public bool shopItemsOn;

	void Start() {
		info = GameObject.Find("Info");
		infoBg = GameObject.Find("InfoBg");
		//infoBg.SetActive(false);
		info.SetActive(false);
	}

	void OnMouseUp() {
		
		shopItemsOn = true;
    	GameObject.Find("BgButton").GetComponent<ShopBgButton>().shopBgOn = false;

		GameObject.Find("ItemButton").GetComponent<Image>().color = new Color (0.627451f, 0.9019608f, 0.5058824f, 1f);
		GameObject.Find("BgButton").GetComponent<Image>().color = new Color (0.4862745f, 0.6078432f, 0.2156863f, 1f);

		
		if (string.Compare(SceneManager.GetActiveScene().name, "Main Menu") == 0)  {
			GameObject.Find("Canvas").GetComponent<MainMenu>().itemsShop.SetActive (true);	
			GameObject.Find("Canvas").GetComponent<MainMenu>().bgShop.SetActive (false);
		} else {
			GameObject.Find("Bottom").GetComponent<Bottom>().itemsShop.SetActive (true);
			GameObject.Find("Bottom").GetComponent<Bottom>().bgShop.SetActive(false);
		}
	}

}
// 