using UnityEngine;
using System.Collections;

public class SpawnItem : MonoBehaviour {

	private bool rotation = false;
	public float speedRotate = 2000f;

	// Use this for initialization
	void Start () {
		GetComponent<RectTransform> ().offsetMin = new Vector2(Random.Range(-650,650),Random.Range(0,1000));
		if (gameObject.tag != "bamboo" && gameObject.tag != "coin" && gameObject.tag != "speedUp") {
			rotation = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if (rotation) {
			transform.Rotate (0, 0, speedRotate * Time.deltaTime);
		}
	}
}
