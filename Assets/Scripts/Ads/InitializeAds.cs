using UnityEngine;
using UnityEngine.Advertisements;

public class InitializeAdsScript : MonoBehaviour { 

    #if UNITY_IOS
    private string gameId = "3579882";
    #elif UNITY_ANDROID
    private string gameId = "3579883";
    #endif

    bool testMode = true;

    void Start () {
        Advertisement.Initialize (gameId, testMode);
    }
}
