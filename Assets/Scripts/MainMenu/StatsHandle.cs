using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsHandle : MonoBehaviour
{
    public GameObject[] bambooSticks;
    public GameObject stateIcon;

    public GameObject timer;

    void Awake() {
    	//stateIcon = GameObject.Find("HungryStateIcon");

    	//timer = GameObject.Find("TimerStateValue");
    }


    void Update() {
    	setHungryState();
    }


    // 16% == first bambooStick active
    // every 12% == +1 bambooStick active
    private void setHungryState() {
    	int score = (int)((float)PlayerPrefs.GetInt("eatenBamboo") / (float)PlayerPrefs.GetInt("maxBamboo") * 100);
    	int activeSticksNum = (score - 4)  / 12;

    	int i = 0;
    	foreach (GameObject stick in bambooSticks) {
    		if (activeSticksNum < i) {
    			stick.SetActive(false);
    		} else {
    			stick.SetActive(true);
    		}
    		i++;
    	}
    } 

    private void timerUpdate() {
		//
	}
}
