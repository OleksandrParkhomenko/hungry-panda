using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollRectSnapToItem : MonoBehaviour 
{
	// Public Variables
	public RectTransform panel;	// To hold the ScrollPanel
	public GameObject[] obj;
	public RectTransform center;	// Center to compare the distance for each button

	// Private Variables
	public float[] distance;	// All buttons' distance to the center
	private bool dragging = false;	// Will be true, while we drag the panel
	public float objDistance;	// Will hold the distance between the buttons
	public int minObjIndex;	// To hold the number of the button, with smallest distance to center
	private int objLength;
	private float minDistance;
	
	private float delta = 0.0f;
	private int expectedObjIndex;

	public bool lastObj;
	public bool firstObj;

	public Vector3 panelPosition;
	
	
	void Awake(){

	}



	void Start() {
		setScrollRectSettings();

		expectedObjIndex = -1;

		objLength = obj.Length;
		distance = new float[objLength];

		lastObj = false;
		firstObj = true;

		// Get distance between buttons
		objDistance  = (float)Mathf.Abs(obj[1].GetComponent<RectTransform>().position.x - obj[0].GetComponent<RectTransform>().position.x);
	}


	void Update() {
		panelPosition = panel.position;
		testScroll();
		
		for (int i = 0; i < obj.Length; i++) {
			distance[i] = center.GetComponent<RectTransform>().position.x - obj[i].GetComponent<RectTransform>().position.x;
			distance[i] = Mathf.Abs(distance[i]);
		}
	
		minDistance = Mathf.Min(distance);	// Get the min distance

		for (int a = 0; a < obj.Length; a++) {
			if (minDistance == distance[a]) {
				minObjIndex = a;
			}
		}
		
		if (!dragging && expectedObjIndex == -1) {
			LerpToBttn(minObjIndex * -objDistance);
		} else if (minObjIndex == expectedObjIndex) {
			expectedObjIndex = -1;
		} else {
			if (expectedObjIndex > minObjIndex) {
				nextObj();
			} else {
				prevObj();
			}
		}
		checkLastFirst();
	}

	private void setScrollRectSettings() {
		objDistance  = (float)Mathf.Abs(obj[1].GetComponent<RectTransform>().position.x - obj[0].GetComponent<RectTransform>().position.x);
		panelPosition = panel.position;
		delta = panelPosition.x + objDistance;
	}

	private void LerpToBttn(float position, float force = 10.0f)
	{
		float newX = Mathf.Lerp (panel.position.x, position+delta, Time.deltaTime * force);
		Vector2 newPosition = new Vector2 (newX, panel.position.y);

		panel.position = newPosition;
	}


	public void StartDrag()
	{
		dragging = true;
	}


	public void EndDrag()
	{
		dragging = false;
	}


	public void nextObj() {
		expectedObjIndex = minObjIndex + 1;
		LerpToBttn(expectedObjIndex * -objDistance);
	}


	public void prevObj() {
		expectedObjIndex = minObjIndex - 1; 
		LerpToBttn(expectedObjIndex * -objDistance);
	}


	private void testScroll() {
		if (Input.GetKeyDown(KeyCode.PageUp)) {
            prevObj();
        }
        if (Input.GetKeyDown(KeyCode.PageDown)) {
            nextObj();
        }
	}

	private void checkLastFirst() {
		if (minObjIndex <= 1) {
			firstObj = true;
			lastObj = false;
		} else if (minObjIndex == objLength - 1) {
			firstObj = false;
			lastObj = true;
		} else {
			firstObj = false;
			lastObj = false;
		}
	}

}













