using UnityEngine;
using System.Collections;



public class EngineInitializationScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject targetBody = Utility.FindNearestBodyWithTag("VehicleBody", gameObject);

		if (targetBody == null) {
			return;
		}
		transform.parent = targetBody.transform;
					
	}



	
	// Update is called once per frame
	void Update () {
	
	}
}
