using UnityEngine;
using System.Collections.Generic;

public class ShipScript {

	private Dictionary<GameObject, IList<GameObject>> shipGraph;

	// Use this for initialization
	void Start () {
		shipGraph = new Dictionary<GameObject, IList<GameObject>> ();
	
	}

	void AddConnection() {

	}

	void RemoveConnection() {


	}


	bool VerifyIntegrity() {
		return false;
	}	
}
