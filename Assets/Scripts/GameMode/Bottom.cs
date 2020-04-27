﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Bottom : MonoBehaviour {

	int counter = 0; //every 2nd lost bamboo you lose 1 life

	public int score;

	public GameObject shopCanvas;
	public GameObject loseCanvas;
	public GameObject itemsShop;
	public GameObject bgShop;

	private GameObject[] backgrounds;

	void Start() {
		score = 0;
		backgrounds = GameObject.FindGameObjectsWithTag("background");
		itemsShop = GameObject.Find("ItemsScrollArea");
		bgShop = GameObject.Find("BgScrollArea");

		shopCanvas = GameObject.Find("ShopCanvas");
		loseCanvas = GameObject.Find ("LoseCanvas");

		shopCanvas.SetActive(false);
		loseCanvas.SetActive(false);
		bgShop.SetActive(false);

	}

	void Update() {
		chooseBackground();
		if (GameObject.Find("Panda")) {
			setScore();
		} else {
			GameObject.Find("FinalScore").GetComponent<FinalScore>().showFinalScore();
		}
	}


	void OnCollisionEnter2D (Collision2D obj) {
		if (obj.gameObject.tag == "bamboo" && GameObject.Find ("Panda").GetComponent<PandaGame> ().lives != 0) {
			counter++;
			if (counter % 2 == 0 && counter != 0) {
				GameObject.Find ("Panda").GetComponent<PandaGame> ().lives--;
			}
		}

		string sceneName = SceneManager.GetActiveScene().name;
		if (sceneName == "ArcadeMode") {
			GameObject.Find ("Canvas").GetComponent<ArcadeMode> ().items.Remove (obj.gameObject);
		} else if (sceneName == "SurvivalMode") {
			GameObject.Find ("Canvas").GetComponent<SurvivalMode> ().items.Remove (obj.gameObject);
		}

		Destroy (obj.gameObject);
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

	private void setScore() {
		score = GameObject.Find("Panda").GetComponent<PandaGame>().points;
		Debug.Log(GameObject.Find("Panda").GetComponent<PandaGame>().points);
	}
}