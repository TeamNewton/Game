using UnityEngine;
using System.Collections;

public class EditorScripts : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Utility.InitializeShipGraph();	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			Debug.Log("Is valid: " + Utility.ShipIsValid());

			if (Utility.ShipIsValid()) {
				Utility.GetShipScript().PrepareShipForLevelLoad();
			}
		}
	}
}
