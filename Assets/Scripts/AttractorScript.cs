using UnityEngine;
using System.Collections;

public class AttractorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	void FixedUpdate() {
		var objects = Utility.GetGameObjects ();

		foreach (GameObject obj in objects) {
			if (obj.rigidbody == null) {
				continue;
			}

			var forceVector = obj.transform.position - transform.position;
			var distanceSqr = Mathf.Max(forceVector.magnitude*forceVector.magnitude, 0.25f);
			var strength = 0.7f;


			obj.rigidbody.AddForce(forceVector.normalized * -strength/distanceSqr);


		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
