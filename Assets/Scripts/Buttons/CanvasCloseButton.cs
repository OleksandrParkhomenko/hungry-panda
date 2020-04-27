using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CanvasCloseButton : MonoBehaviour {

	void OnMouseUp() {
	
		if (string.Compare(SceneManager.GetActiveScene().name, "Main Menu") == 0)  {
			GameObject.Find ("Records").GetComponent<Collider2D> ().enabled = true;
			GameObject.Find ("Shop").GetComponent<Collider2D> ().enabled = true;
			GameObject.Find ("Play").GetComponent<Collider2D> ().enabled = true;
			GameObject.Find("PandaMainMenu").GetComponent<Collider2D> ().enabled = true;

			GameObject.Find("Canvas").GetComponent<MainMenu>().recordsCanvas.SetActive (false);
			GameObject.Find("Canvas").GetComponent<MainMenu>().shopCanvas.SetActive (false);
			GameObject.Find("Canvas").GetComponent<MainMenu>().chooseModeCanvas.SetActive (false);
		} else {
			GameObject.Find("Bottom").GetComponent<Bottom>().shopCanvas.SetActive (false);
			GameObject.Find("Bottom").GetComponent<Bottom>().loseCanvas.SetActive(true);
		}
	}
}
