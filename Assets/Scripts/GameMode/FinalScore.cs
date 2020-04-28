﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour {
    
    private int score;

    void Awake() {
    }

    void Update() {
        
    }

    void OnDestroy() {
        // Bottom.cs line 45
    }

    public void showFinalScore() {
        if ( SceneManager.GetActiveScene().name == "ArcadeMode") {
            setScore();
            setEatenBamboo(); //save to PlayerPrefs   
        }
    }

    private void setEatenBamboo() {
        int eatenBamboo = PlayerPrefs.GetInt("eatenBamboo") + score;
        int maxBamboo =  PlayerPrefs.GetInt("maxBamboo");
        float timePerBamboo = PlayerPrefs.GetFloat("maxHungryTime") / maxBamboo;


        if (eatenBamboo < maxBamboo) {
           PlayerPrefs.SetInt("eatenBamboo", eatenBamboo);
           PlayerPrefs.SetFloat("hungryTime", eatenBamboo * timePerBamboo);
        } else {
           PlayerPrefs.SetInt("eatenBamboo", maxBamboo);
           PlayerPrefs.SetFloat("hungryTime", PlayerPrefs.GetFloat("maxHungryTime"));
        }
    }

    private void setScore() {
        score = GameObject.Find ("Bottom").GetComponent<Bottom> ().score;
        GetComponent<Text>().text = "score: " + score;
    }

}