using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour {
    
    private int score;

    void Awake() {
    }

    void Update() {
        
    }

    public void showFinalScore() {
        setScore();
        setEatenBamboo(); //save to PlayerPrefs        
    }

    private void setEatenBamboo() {
        int eatenBamboo = PlayerPrefs.GetInt("eatenBamboo") + score;
        int maxBamboo =  PlayerPrefs.GetInt("maxBamboo");

        if (eatenBamboo <= maxBamboo) {
           PlayerPrefs.SetInt("eatenBamboo", eatenBamboo);
        } else {
           PlayerPrefs.SetInt("eatenBamboo", maxBamboo);
        }
    }

    private void setScore() {
        score = GameObject.Find ("Bottom").GetComponent<Bottom> ().score;
        GetComponent<Text>().text = "score: " + score;
    }

}