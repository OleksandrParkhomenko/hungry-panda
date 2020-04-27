using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoItem : MonoBehaviour
{

   void OnMouseUp() {
   		GameObject info = GameObject.Find("ItemButton").GetComponent<ShopItemsButton>().info;
   		info.SetActive(true);

   		string itemName = transform.parent.name;

   		info.GetComponent<Text>().text = transform.parent.GetChild(1).gameObject.GetComponent<BuyItemButton>().info[itemName];
   		StartCoroutine(HideInfo());
   		//GameObject.Find("ItemButton").GetComponent<ShopItemsButton>().infoBg.SetActive(true);
   }

   private	IEnumerator HideInfo(){
    	GameObject info = GameObject.Find("ItemButton").GetComponent<ShopItemsButton>().info;
    	if (info.GetComponent<Text>().text != "Not enough coins" && info.GetComponent<Text>().text != "") {
    		yield return new WaitForSeconds (2.5f);
    		info.GetComponent<Text>().text = "";
   			info.SetActive(false);
    	}
 	}
}
