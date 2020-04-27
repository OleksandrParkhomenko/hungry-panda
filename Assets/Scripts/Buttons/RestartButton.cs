using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

	// Use this for initialization
	void OnMouseUp() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex) ;
	}

}
