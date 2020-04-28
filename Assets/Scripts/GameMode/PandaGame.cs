using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System;

public class PandaGame : MonoBehaviour {

	public int lives = 1;
	public int points = 0;
    public float speed = 0.1f;
	public float eps = 0.2f;
	private bool speedUp = false;
	private float speedUpTimer = 5f;
	public string hat = "none";
	public int hatCounter = 0;
	public int currCoins = 0;

	public Animator anim;

	private RectTransform itemRTransform;
	private string currItemName;

	public GameObject shopCanvas;
	public GameObject loseCanvas;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		
		gameObject.SetActive(true);
		
		chooseBackground();
		chooseItem();
	}
		


	// Update is called once per frame
	void Update () {
		if (GameObject.Find("Canvas")) { //!!!
			if (Input.touchCount > 0 && Input.GetTouch (0).phase != TouchPhase.Ended &&
				(Input.GetTouch (0).position.x / Screen.width * 5.0f - 2.5f >= transform.position.x + eps ||
					Input.GetTouch (0).position.x / Screen.width * 5.0f - 2.5f <= transform.position.x - eps)) {

				if (Input.GetTouch (0).position.x / Screen.width * 5.0f - 2.5f > transform.position.x) {
					transform.localRotation = Quaternion.Euler (0, 0, 0);
					transform.position = new Vector3 (transform.position.x + speed, transform.position.y, 0);
					anim.SetInteger ("state", 1);	
					itemRTransform.rotation = transform.localRotation;
					//itemRTransform.rotation = Quaternion.Euler(0, transform.localRotation.y  + 180, 0);
				}

				if (Input.GetTouch (0).position.x / Screen.width * 5.0f - 2.5f < transform.position.x) {
					transform.localRotation = Quaternion.Euler (0, 180, 0);
					transform.position = new Vector3 (transform.position.x - speed, transform.position.y, 0);
					anim.SetInteger ("state", 1);
					itemRTransform.rotation = transform.localRotation;
					//itemRTransform.rotation = Quaternion.Euler(0, transform.localRotation.y  + 180, 0);
				}

			} else { //if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended){
				anim.SetInteger ("state", 0);
			}

			if (Input.GetAxis("Horizontal") > 0) {
			transform.localRotation = Quaternion.Euler (0, 0, 0);
			anim.SetInteger ("state", 1);	
		} else if (Input.GetAxis("Horizontal") < 0) {
			transform.localRotation = Quaternion.Euler (0, 180, 0);
			anim.SetInteger ("state", 1);	
		}
		}

		if (speedUp) {
			speedUpTimer -= Time.deltaTime;
			if (speedUpTimer <= 0) { //reset speedUp
				speedUp = false;
				speedUpTimer = 5f;
				speed /= 2f;
			}
		} 

		if (hatCounter == 0 && string.Compare(currItemName, "none") != 0) {
			GameObject.Find (currItemName).SetActive(false);
			PlayerPrefs.SetString("item", "none");
			PlayerPrefs.SetInt(currItemName, 0);
		}

		takeScreenShot();
	}


	void OnDestroy() {
		GameObject.Find("FinalScore").GetComponent<FinalScore>().showFinalScore();
	}
   
	void OnCollisionEnter2D (Collision2D obj) {
		//if Player has item - item handle collision 
		if (string.Compare(PlayerPrefs.GetString("item"), "none") == 0){
			HandleCollision(obj);
		}
	}


	public void HandleCollision(Collision2D obj) {
		if (obj.gameObject.tag == "bamboo") {
			points++;
		} else if (obj.gameObject.tag == "additionalLife") {
			lives++;
		} else if (obj.gameObject.tag == "speedUp") {
			speed *= 2f;
			speedUp = true;
		} else if (obj.gameObject.tag == "stone" || obj.gameObject.tag == "shuriken") {
			if (hatCounter > 0) hatCounter--;
			else lives--;
		} else if (obj.gameObject.tag == "coin") {
			currCoins += 1;
			PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 1);
		} else if (obj.gameObject.tag == "arrow") {
			lives--;
		}

		string sceneName = SceneManager.GetActiveScene().name;
		if (sceneName == "ArcadeMode") {
			GameObject.Find ("Canvas").GetComponent<ArcadeMode> ().items.Remove (obj.gameObject);
		} else if (sceneName == "SurvivalMode") {
			GameObject.Find ("Canvas").GetComponent<SurvivalMode> ().items.Remove (obj.gameObject);
		}

		Destroy (obj.gameObject);
	}

	void FixedUpdate() {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (Input.GetAxis ("Horizontal") * 3f, GetComponent<Rigidbody2D> ().velocity.y);
		if (Input.GetAxis("Horizontal") > 0) {
			transform.localRotation = Quaternion.Euler (0, 0, 0);
			anim.SetInteger ("state", 1);	
		} else if (Input.GetAxis("Horizontal") < 0) {
			transform.localRotation = Quaternion.Euler (0, 180, 0);
			anim.SetInteger ("state", 1);	
		}
	}




	//hat rotation // KOSTYL' GY
	void HatUp() {
		//itemRTransform.rotation = Quaternion.Euler(0, 180, 0);
	}

	void RotateHat() {
		if (itemRTransform.rotation.y == 0){
			itemRTransform.rotation = Quaternion.Euler(0, 180, 0);

		} else {
			itemRTransform.rotation = Quaternion.Euler(0, 0, 0);
		}
	}

	void RotateAndMoveHat() {
		itemRTransform.localRotation = Quaternion.Euler(0, 180, 0);
		//itemRTransform.localPosition = new Vector3(0.12f, 0.7f, 0);
		
	}

	void NormalizeHat() {
		itemRTransform.localRotation = Quaternion.Euler(0, 0, 0);
		//itemRTransform.localPosition = new Vector3(0.6f, 0.7f, 0);
		//itemRTransform.anchoredPosition = new Vector2(0.6f, 0.7f);
	}


	private void takeScreenShot() {
		string folderPath = System.IO.Directory.GetCurrentDirectory() + "/Screenshots/";
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (!System.IO.Directory.Exists(folderPath)) {
				System.IO.Directory.CreateDirectory(folderPath);
	 		}
	        var screenshotName = "Screenshot_" + System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".png";
	        ScreenCapture.CaptureScreenshot(System.IO.Path.Combine(folderPath, screenshotName));
	        Debug.Log(folderPath + screenshotName);
		}

        
	}

	private void chooseBackground() {
		GameObject[] backgrounds = GameObject.FindGameObjectsWithTag("background");

		foreach (GameObject bg in backgrounds){
			if (string.Compare(bg.name, PlayerPrefs.GetString("background")) != 0){
				//bg.SetActive(false);
			}
		} 
	}

	private void chooseItem() {
		currItemName = PlayerPrefs.GetString("item"); 
		GameObject[] items = GameObject.FindGameObjectsWithTag("item");

		//hide every item except current
		foreach (GameObject item in items) {
			if (string.Compare(item.name, currItemName) != 0){ //not equal
				item.SetActive(false);
			} else {
				itemRTransform = item.GetComponent<RectTransform> ();
			}
		}

		if (string.Compare(currItemName, "none") != 0) getBoost();
	}

	private void getBoost() {

		if (string.Compare(currItemName, "redhardhat") == 0) {
			hatCounter = 1;
		} else if (string.Compare(currItemName, "bluehardhat") == 0) {
			hatCounter = 2;
		} else if (string.Compare(currItemName, "speedhat") == 0) {
			hatCounter = 1;
			speed *= 2f;
		} else if (string.Compare(currItemName, "whitehardhat") == 0) {
			hatCounter = 4;
		} else {
			hatCounter = 1;
		}

	}
}
