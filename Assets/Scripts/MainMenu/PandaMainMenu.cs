using UnityEngine;
using System.Collections;

public class PandaMainMenu : MonoBehaviour {

	Animator anim;
	GameObject camera;
	Transform cameraTransform;


	bool direction = true; // 'true' if goes to the right
	float clicked = 0f;

	private RectTransform hatRTransform;
	private GameObject[] backgrounds;
	private GameObject defaultBg;
	
	// Use this for initialization
	void Start () {
		backgrounds = GameObject.FindGameObjectsWithTag("background");
		anim = GetComponent<Animator>();
		camera = GameObject.Find ("Main Camera");
		cameraTransform = camera.GetComponent<Transform> ();

	}

	// Update is called once per frame
	void Update () {
		//chooseItem();
		chooseBackground();

		if (clicked > 0) {
			if (direction) {
				transform.position = new Vector3 (transform.position.x + 0.02f, transform.position.y, transform.position.z);
				cameraTransform.position = new Vector3 (cameraTransform.position.x + 0.02f, cameraTransform.position.y, cameraTransform.position.z);

				clicked -= 0.02f;
				if (transform.position.x >= 5) {
					direction = false;
					transform.localRotation = Quaternion.Euler (0, 180, 0);
				}	
			} else {
				transform.position = new Vector3 (transform.position.x - 0.02f, transform.position.y, transform.position.z);
				cameraTransform.position = new Vector3 (cameraTransform.position.x - 0.02f, cameraTransform.position.y, cameraTransform.position.z);
				clicked -= 0.02f;
				if (transform.position.x <= -5) {
					direction = true;
					transform.localRotation = Quaternion.Euler (0, 0, 0);
				}
			}
		}  else {
			clicked = 0;
			anim.SetInteger("state", 0);
		}



	}

	void OnMouseDown () {
		if (clicked > 0) {
			clicked = 0;
		} else {
			clicked = Random.Range (0.5f, 6.5f);
			anim.SetInteger ("state", 1);
		}

	}

	private void chooseBackground() {
		
		foreach (GameObject bg in backgrounds){
			if (string.Compare(bg.name, PlayerPrefs.GetString("background")) != 0){
				bg.SetActive(false);
			} else {
				bg.SetActive(true);
			}
		} 
	}

	// private void chooseItem() {
	// 	currItemName = PlayerPrefs.GetString("item"); 
	// 	GameObject[] items = GameObject.FindGameObjectsWithTag("item");

	// 	//hide every item except current
	// 	foreach (GameObject item in items) {
	// 		if (string.Compare(item.name, currItemName) != 0){ //not equal
	// 			item.SetActive(false);
	// 		} else {
	// 			itemRTransform = item.GetComponent<RectTransform> ();
	// 		}
	// 	}

	// 	//if (string.Compare(currItemName, "none") != 0) getBoost();
	// }


	
}
