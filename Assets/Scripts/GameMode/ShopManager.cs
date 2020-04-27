using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject leftArrow;
	public GameObject rightArrow;

	void Awake() {
		setArrows();
		GameObject.Find("CoinsAmount").GetComponent<Text>().text = PlayerPrefs.GetInt("coins").ToString();
	}

	void Start() {
		GameObject.Find("ItemButton").GetComponent<ShopItemsButton>().shopItemsOn = true; //buttons state
   		GameObject.Find("BgButton").GetComponent<ShopBgButton>().shopBgOn = false;
   	}

   	void Update() {
   		if (GameObject.Find("ItemButton").GetComponent<ShopItemsButton>().shopItemsOn) {
   			manageArrows(GameObject.Find("ItemsScrollControl"));
   		} else if (GameObject.Find("BgButton").GetComponent<ShopBgButton>().shopBgOn) {
   			manageArrows(GameObject.Find("BgScrollControl"));
   		}
   		GameObject.Find("CoinsAmount").GetComponent<Text>().text = PlayerPrefs.GetInt("coins").ToString();
   	}


	private void setArrows() {
		leftArrow = GameObject.Find("LeftArrow");
		rightArrow = GameObject.Find("RightArrow");
	}

	private void manageArrows(GameObject scrollRectControl) {
		leftArrow.SetActive(true);
		rightArrow.SetActive(true);
		if (scrollRectControl.GetComponent<ScrollRectSnapToItem>().lastObj) {
			rightArrow.SetActive(false);
		} else if (scrollRectControl.GetComponent<ScrollRectSnapToItem>().firstObj) {
			leftArrow.SetActive(false);
		}
	}
}
