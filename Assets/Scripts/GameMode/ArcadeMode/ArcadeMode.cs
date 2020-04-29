using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArcadeMode : MonoBehaviour {

	public GameObject panda_default;
	public GameObject panda_red_hardhat;
	public GameObject panda_yellow_hardhat;
	
	public GameObject[] lives;
	public GameObject pauseCanvas, pauseButton, panda, loseCanvas, shopCanvas,
					  bamboo, luck, additionalLife, speedUp, shuriken, stone, coin; //items
	public int currNumOfLives = 1;
	public List<GameObject> items;
	public bool pause = false;
	public bool gameOver = false;
	public int score;

	float timerTurn = 2f;
	float timeCounter = 0f;
	float gravityScale = 0.35f;
	int itemCounter = 0;
	int timeForAddLife = -1;
	int timeForLuck = -1;
	int timeForCoin = -1;
	int timeForSpeedUp = -1;
	int timeForShuriken = -1;
	int timeForStone = -1;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("adsCounter", PlayerPrefs.GetInt("adsCounter") + 1);

		timeForAddLife = Random.Range (5, 25);
		timeForCoin = Random.Range (5, 10);
		timeForSpeedUp = Random.Range (10, 20);
		timeForStone = Random.Range (3, 8);

		for (int i = 1; i < 3; i++) {
			lives [i].SetActive (false);
		}
		loseCanvas = GameObject.Find ("LoseCanvas");
		pauseCanvas = GameObject.Find ("PauseCanvas");
		pauseButton = GameObject.Find ("Pause");
		shopCanvas = GameObject.Find("ShopCanvas");
		panda = GameObject.Find ("Panda");
		pauseCanvas.SetActive (false);
		//loseCanvas.SetActive (false);
		//shopCanvas.SetActive(false); //both deactivate in Bottom.cs

	}

	void GameOver() {
		GetComponent<InterstitialAds>().checkAdCounter();

		loseCanvas.SetActive (true);
		score = GameObject.Find ("Panda").GetComponent<PandaGame> ().points;
		Destroy(GameObject.Find("Canvas"));
		Destroy(GameObject.Find("Panda"));

		if (PlayerPrefs.HasKey ("record")) {
			if (PlayerPrefs.GetInt ("record") < score) {
				PlayerPrefs.SetInt ("record", score);
			} else {
				GameObject.Find ("NewRecord").SetActive (false);
			}
		} else {
			PlayerPrefs.SetInt("record", score);
		}
	}

	void ResetItemTimer() {
		timeForStone = itemCounter + Random.Range (1, 6);
		timeForAddLife = itemCounter + Random.Range (4, 10);
		timeForCoin = itemCounter + Random.Range (1, 6);
		timeForSpeedUp = itemCounter + Random.Range (1, 6);
	}

	// Update is called once per frame
	void Update () {

		if (panda.GetComponent<PandaGame> ().lives <= 0) {
			gameOver = true;
			GameOver ();
		}
		if (!gameOver && !pause) {
			//controling num of lives
			if (panda.GetComponent<PandaGame> ().lives > currNumOfLives && panda.GetComponent<PandaGame> ().lives <= 3) {
				lives [currNumOfLives].SetActive (true);
				currNumOfLives++;
			} else if (panda.GetComponent<PandaGame> ().lives < currNumOfLives) {
				lives [currNumOfLives - 1].SetActive (false);
				currNumOfLives--;
			}
					
			//spawning items
			if (timer ()) {
				GameObject currGO;
				if (itemCounter == timeForStone) {
					currGO = Instantiate (stone);
					timeForAddLife++;
					timeForCoin++;
					timeForSpeedUp++;
					timeForStone += Random.Range (4, 9);
				} else if (itemCounter == timeForAddLife) {
					currGO = Instantiate (additionalLife);
					timeForStone++;
					timeForCoin++;
					timeForSpeedUp++;
					timeForAddLife += Random.Range (10, 15);
				} else if (itemCounter == timeForCoin) {
					currGO = Instantiate (coin);
					timeForStone++;
					timeForAddLife++;
					timeForSpeedUp++;
					timeForCoin += Random.Range (3, 10);
				} else if (itemCounter == timeForSpeedUp) {
					currGO = Instantiate (speedUp);
					timeForStone++;
					timeForAddLife++;
					timeForCoin++;
					timeForSpeedUp += Random.Range (8, 15);
				} else {
					currGO = Instantiate (bamboo);
				}
				currGO.transform.SetParent (this.gameObject.transform, false);
				items.Add (currGO);
				Rigidbody2D rb = currGO.GetComponent<Rigidbody2D> ();
				rb.gravityScale = gravityScale;

				itemCounter++;
				if (itemCounter % 7 == 0) {
					gravityScale += 0.08f;
				} 
				if (itemCounter % 10 == 0) {
					if (timerTurn > 1.2f) {
						timerTurn -= 0.05f;
					}
				}
			}
		} 
			
	}
	
	bool timer() {
		if (!pause && !gameOver) {
			if (timerTurn > timeCounter) {
				timeCounter += Time.deltaTime;
				return false;
			} else if (timerTurn <= timeCounter) {
				timeCounter = 0f;
				return true;
			}
		}
		return false;
	}


}

