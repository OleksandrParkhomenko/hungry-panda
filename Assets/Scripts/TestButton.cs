using UnityEngine;
using System.Collections;

public class TestButton : MonoBehaviour { 

	void OnMouseDown() {
		transform.localScale *= 1.2f;
		Debug.Log("Mouse Down");
	}

	void OnMouseUp() {
		transform.localScale /= 1.2f;
		Debug.Log("Mouse Up");
	}

}