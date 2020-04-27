using UnityEngine;
using System.Collections;


	
public class Arrow : MonoBehaviour {

	public float _angle;
	Vector3 pos, target;
	float dist;

	void Start() {
		//_angle = 20f;// Random.Range(20f,70f);
		//transform.SetParent(GameObject.Find("Canvas").GetComponent<Transform>(), false);
		Launch();
	}

	void OnGUI() {
		GUI.Label (new Rect (10, 350, 100, 100), "" + dist);
	}

	private void Launch()
	{
		// source and target positions
		pos = transform.position;
		target = GameObject.Find ("Panda").GetComponent<Transform> ().position;


		// distance between target and source
		dist = Vector3.Distance (pos, target);

	
		// rotate the object to face the target
		transform.LookAt(target);

		// calculate initival velocity required to land the cube on target using the formula (9)
		float Vi = Mathf.Sqrt(dist * -Physics.gravity.y / (Mathf.Sin(Mathf.Deg2Rad * _angle * 2)));
		float Vy, Vz;   // y,z components of the initial velocity
	
		Vy = Vi * Mathf.Sin(Mathf.Deg2Rad * _angle);
		Vz = Vi * Mathf.Cos(Mathf.Deg2Rad * _angle);
	
		// create the velocity vector in local space
		Vector3 localVelocity = new Vector3(0f, Vy+3, Vz+1);
	
		// transform it to global vector
		Vector3 globalVelocity = transform.TransformVector(localVelocity);
	
		// launch the cube by setting its initial velocity
		GetComponent<Rigidbody2D>().velocity = globalVelocity;


	}

	void Update()
    {
  //       if (Input.GetKeyDown(KeyCode.Space))
  //       {
		// 	Launch();
  //       }
		dist = Vector3.Distance (pos, target);
    }

	void FixedUpdate() {
		Vector2 v = GetComponent<Rigidbody2D>().velocity;
		float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

}

