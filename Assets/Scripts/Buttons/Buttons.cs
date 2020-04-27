using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour { 

	void OnMouseDown() {
		transform.localScale *= 1.2f;
	}

	void OnMouseUp() {
		transform.localScale /= 1.2f;
	}

}