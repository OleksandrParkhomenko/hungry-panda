using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour { 

    #if UNITY_IOS
    private string gameId = "3579882";
    #elif UNITY_ANDROID
    private string gameId = "3579883";
    #endif

    bool testMode = true;
    private int adShowingStep = 5;

    void Start () {
        // Initialize the Ads service:
    }


	public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished) {
            Debug.Log("Interstitial showed ad to completion.");
        } else if (showResult == ShowResult.Skipped) {
            Debug.Log("Interstitial ad skiped.");
        } else if (showResult == ShowResult.Failed) {
            Debug.Log ("The ad did not finish due to an error.");
        }
    }

    public void checkAdCounter() {
    	int adsCounter = PlayerPrefs.GetInt("adsCounter");
    	if (adsCounter >= adShowingStep) {
    		showAd();
    		PlayerPrefs.SetInt("adsCounter", 0);
    	} else {
			//PlayerPrefs.SetInt("adsCounter", adsCounter + 1);
    	}
    }

	private void showAd() {
    	Advertisement.Initialize (gameId, testMode);
    	Advertisement.Show ();
	}

}