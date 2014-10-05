using UnityEngine;
using System.Collections;

public class AttractorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	void FixedUpdate() {
		GameObject[] objects = GameObject.FindGameObjectsWithTag("VehicleBody");

		foreach (GameObject obj in objects) {
			if (obj.rigidbody == null) {
				continue;
			}

			var forceVector = obj.transform.position - transform.position;
			var distanceSqr = forceVector.magnitude*forceVector.magnitude;


			obj.rigidbody.AddForce(forceVector.normalized * -0.25f/distanceSqr);


		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
