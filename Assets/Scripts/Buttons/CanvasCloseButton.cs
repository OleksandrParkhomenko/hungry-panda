using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CanvasCloseButton : MonoBehaviour {

	void OnMouseUp() {
	
		if (string.Compare(SceneManager.GetActiveScene().name, "Main Menu") == 0)  {
			GameObject.Find("Canvas").GetComponent<MainMenu>().recordsCanvas.SetActive (false);
			GameObject.Find("Canvas").GetComponent<MainMenu>().shopCanvas.SetActive (false);
			GameObject.Find("Canvas").GetComponent<MainMenu>().infoCanvas.SetActive (false);

			if (transform.parent.name != "InfoCanvas") {
				GameObject.Find("Canvas").GetComponent<MainMenu>().chooseModeCanvas.SetActive (false);
				GameObject.Find ("Records").GetComponent<Collider2D> ().enabled = true;
				GameObject.Find ("Shop").GetComponent<Collider2D> ().enabled = true;
				GameObject.Find ("Play").GetComponent<Collider2D> ().enabled = true;
				GameObject.Find("PandaMainMenu").GetComponent<Collider2D> ().enabled = true;
			} else {
				GameObject.Find("Canvas").GetComponent<MainMenu>().chooseModeCanvas.SetActive (true);
			}
			
		} else {
			GameObject.Find("Bottom").GetComponent<Bottom>().shopCanvas.SetActive (false);
			GameObject.Find("Bottom").GetComponent<Bottom>().infoCanvas.SetActive (false);
			GameObject.Find("Bottom").GetComponent<Bottom>().loseCanvas.SetActive(true);
		}
	}
}
