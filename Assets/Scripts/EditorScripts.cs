using UnityEngine;
using System.Collections;

public class EditorScripts : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {

			if (Utility.ShipIsValid()) {
				Utility.GetShipScript().PrepareShipForLevelLoad();
				Application.LoadLevel ("level1");
			}
		}
	}
}
