using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInfoItem : MonoBehaviour
{
    void OnMouseUp() {
   		GameObject.Find("ItemButton").GetComponent<ShopItemsButton>().info.SetActive(false);
   		GameObject.Find("ItemButton").GetComponent<ShopItemsButton>().infoBg.SetActive(false);
   }
}
