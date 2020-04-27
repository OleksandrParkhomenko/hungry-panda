using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsShop : MonoBehaviour
{
	private GameObject scrollRectControl;

	void OnMouseUp() {

		if (GameObject.Find("BgButton").GetComponent<ShopBgButton>().shopBgOn) {
			scrollRectControl = GameObject.Find("BgScrollControl");
		} else if (GameObject.Find("ItemButton").GetComponent<ShopItemsButton>().shopItemsOn) {
			scrollRectControl = GameObject.Find("ItemsScrollControl");
		}

		if (gameObject.name == "LeftArrow") {
			Debug.Log("LeftArrow pressed");
			scrollRectControl.GetComponent<ScrollRectSnapToItem>().prevObj();
		} else if (gameObject.name == "RightArrow") {
			Debug.Log("RightArrow pressed");
			scrollRectControl.GetComponent<ScrollRectSnapToItem>().nextObj();
		}
	}
}
