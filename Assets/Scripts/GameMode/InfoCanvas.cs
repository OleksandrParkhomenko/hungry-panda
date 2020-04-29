using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoCanvas : MonoBehaviour
{
	private string arcadeModeInfo = "Panda has eaten too much bamboo. Go to Survival Mode to burn some calories!";
	private string survivalModeInfo = "Panda is hungry! Go to Arcade Mode and try to catch some bamboo!";
    // Start is called before the first frame update
    public string mode;

    public void chooseMode(string modeName) {
    	if (modeName == "ArcadeMode") {
    		GetComponent<Text>().text = arcadeModeInfo;	
    	} else if (modeName == "SurvivalMode") {
    		GetComponent<Text>().text = survivalModeInfo;	
    	}
    	mode = modeName;
    }
}
