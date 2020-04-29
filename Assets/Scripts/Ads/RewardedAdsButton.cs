using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class RewardedAdsButton : MonoBehaviour, IUnityAdsListener {

    #if UNITY_IOS
    private string gameId = "3579882";
    #elif UNITY_ANDROID
    private string gameId = "3579883";
    #endif

    bool testMode = true;

    private bool playedOnce;

    Button myButton;
    public string myPlacementId = "rewardedVideo";

    void Start () {   
        myButton = GetComponent <Button> ();

        // Set interactivity to be dependent on the Placement’s status:
        myButton.interactable = Advertisement.IsReady (myPlacementId); 

        // Map the ShowRewardedVideo function to the button’s click listener:
        //if (myButton) myButton.onClick.AddListener (ShowRewardedVideo);

        // Initialize the Ads listener and service:
        Advertisement.AddListener (this);
        Advertisement.Initialize (gameId, testMode);
    }

    // Implement a function for showing a rewarded video ad:
    void ShowRewardedVideo () {
        playedOnce = true;
        Advertisement.Show (myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady (string placementId) {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == myPlacementId) {        
            myButton.interactable = true;
        }
    }

    void OnMouseUp() {
        ShowRewardedVideo();
    }

    public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished) {
            Debug.Log("Reward the user for watching the ad to completion.");
            if (playedOnce) {
                getReward();
                playedOnce = false;
            }
        } else if (showResult == ShowResult.Skipped) {
            Debug.Log("Do not reward the user for skipping the ad.");
        } else if (showResult == ShowResult.Failed) {
            Debug.Log ("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsDidError (string message) {
        // Log the error.
    }

    public void OnUnityAdsDidStart (string placementId) {
        // Optional actions to take when the end-users triggers an ad.
    } 

    public void getReward() {
        string mode = GameObject.Find("InfoCanvasText").GetComponent<InfoCanvas>().mode;
        if (mode == "ArcadeMode") {
            getRewardArcade();
        } else if (mode == "SurvivalMode") {
            getRewardSurvival();
        }
        updateEatenBamboo();
    }

    private void getRewardArcade(){
    	float reward = PlayerPrefs.GetFloat("maxHungryTime") * 0.1f;
    	if (PlayerPrefs.GetFloat("hungryTime") < reward) {
    		PlayerPrefs.SetFloat("hungryTime", 0.0f);
            Debug.Log("Arcade reward = to null");
		} else {
			PlayerPrefs.SetFloat("hungryTime", (PlayerPrefs.GetFloat("hungryTime") - reward));
            Debug.Log("Arcade reward - " + (PlayerPrefs.GetFloat("hungryTime") - reward));
		}
    }

    private void getRewardSurvival(){
        float maxHungryTime = PlayerPrefs.GetFloat("maxHungryTime");
        float reward =  maxHungryTime * 0.15f;

        if (PlayerPrefs.GetFloat("hungryTime") + reward >= maxHungryTime) {
            PlayerPrefs.SetFloat("hungryTime", maxHungryTime);
            Debug.Log("Survival reward = to max");
        } else {
            PlayerPrefs.SetFloat("hungryTime", (PlayerPrefs.GetFloat("hungryTime") + reward));
            Debug.Log("Survival reward + " + (PlayerPrefs.GetFloat("hungryTime") + reward));
        }
    }


    private void updateEatenBamboo() {
        float currTimer = PlayerPrefs.GetFloat("hungryTime");
        float timePerBamboo = PlayerPrefs.GetFloat("maxHungryTime") / PlayerPrefs.GetInt("maxBamboo");
        int eatenBamboo = (int) (currTimer / timePerBamboo) + 1;
        
        PlayerPrefs.SetInt("eatenBamboo", eatenBamboo);
    }
}