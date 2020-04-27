using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    void OnMouseUp() {
		GameObject.Find ("Records").GetComponent<Collider2D> ().enabled = false;
		GameObject.Find ("Shop").GetComponent<Collider2D> ().enabled = false;
		GameObject.Find("Canvas").GetComponent<MainMenu>().chooseModeCanvas.SetActive (true);
	}
}
