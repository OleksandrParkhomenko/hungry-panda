using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Points : MonoBehaviour {


	// Use this for initialization
	void Start () {
		GetComponent<Text> ().text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text> ().text = GameObject.Find ("Panda").GetComponent<PandaGame> ().points.ToString();
	}
}
