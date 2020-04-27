using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Magnet : MonoBehaviour 
{
	private float speed = 10.0f;
    private Vector2 target;
    private Vector2 position;
    private Transform magnet;
    private bool hasMagnet;

    void Start()
    {
        target = new Vector2(0.0f, 0.0f);
        position = gameObject.transform.position;

        if (tag == "coin"){
            hasMagnet = string.Compare(PlayerPrefs.GetString("item"), "truckethat") == 0;
        } else if (tag == "bamboo") {
            hasMagnet = string.Compare(PlayerPrefs.GetString("item"), "greenpanama") == 0;
        }
        
        magnet = GameObject.FindGameObjectWithTag("item").transform;
    }

    void Update()
    {
    	if (hasMagnet && transform.position.y <= 0) {
	        float step = speed * Time.deltaTime;
	        target = new Vector2(magnet.position.x, magnet.position.y);

	        // move sprite towards the target location
	        transform.position = Vector2.MoveTowards(transform.position, target, step);
	    }
    }
}