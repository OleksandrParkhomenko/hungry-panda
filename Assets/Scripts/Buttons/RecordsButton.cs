using UnityEngine;
using System.Collections;

public class RecordsButton : MonoBehaviour {

	// Use this for initialization
	void OnMouseUp() {
		GameObject.Find ("Records").GetComponent<Collider2D> ().enabled = false;
		GameObject.Find ("Shop").GetComponent<Collider2D> ().enabled = false;
		GameObject.Find("Canvas").GetComponent<MainMenu>().recordsCanvas.SetActive (true);
	}
}
