using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatBehaviour : MonoBehaviour
{
   void OnCollisionEnter2D (Collision2D obj) {
   		GameObject panda = GameObject.Find("Panda");
		panda.GetComponent<PandaGame>().HandleCollision(obj);
	}
}
