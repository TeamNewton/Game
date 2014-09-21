using UnityEngine;
using System.Collections;

public class AttractorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	void FixedUpdate() {
		GameObject[] objects = GameObject.FindGameObjectsWithTag("VehicleBody");

		foreach (GameObject obj in objects) {
			if (obj.rigidbody2D == null) {
				continue;
			}

			var forceVector = obj.transform.position - transform.position;


			obj.rigidbody2D.AddForce(forceVector.normalized * -0.05f);


		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
