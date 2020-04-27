using UnityEngine;
using System.Collections;

public class MusicButton : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		if (PlayerPrefs.HasKey("music") && PlayerPrefs.GetInt ("music") == 0) {
			AudioListener.pause = true;
		}
		anim.SetBool ("music", !AudioListener.pause);
	}

	// Update is called once per frame
	void Update() {
		anim.SetBool ("music", !AudioListener.pause);
	}

	void OnMouseUp() {
		AudioListener.pause = !AudioListener.pause;
		if (AudioListener.pause) {
			PlayerPrefs.SetInt ("music", 0);
		} else {
			PlayerPrefs.SetInt ("music", 1);
		}
	}
}
