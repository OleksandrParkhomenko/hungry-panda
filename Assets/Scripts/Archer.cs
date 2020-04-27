using UnityEngine;
using System.Collections;

public class Archer : MonoBehaviour {

	public bool archer;
	public GameObject arrow;
	private Animator anim;

	void StopAnimation() {
		GetComponent<Animator> ().enabled = false;
		archer = false;

	}

	void ShootArrows() {
		Instantiate (arrow);
	}
	// Use this for initialization
	void Start () {
		archer = true;
		anim = GetComponent<Animator> ();
		transform.position = new Vector3 (-8f, transform.position.y, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -6f) {
			anim.SetInteger ("state", 0);		
			transform.position = new Vector3 (transform.position.x + 0.05f, transform.position.y, 0);
		} else {
			anim.SetInteger ("state", 1); 
		}
		if (Input.GetKeyDown(KeyCode.Space)){
			ShootArrows();
		}
	}
}
