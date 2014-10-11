using UnityEngine;
using System.Collections.Generic;

public class ShipScript  : MonoBehaviour{

	ShipGraph shipGraph;

	public void Start() {
		shipGraph = new ShipGraph();
	}

	public Dictionary<GameObject, IList<GameObject>> GetShipGraph() {
		return shipGraph.Graph;
	}

	public void SetConnectableObjects(List<GameObject> objects) {
		shipGraph.Initialize (objects);
	}

	public void AddConnection(GameObject obj1, GameObject obj2) {
		shipGraph.AddConnection (obj1, obj2);
	}


	public void RemoveConnection(GameObject obj1, GameObject obj2) {
		shipGraph.RemoveConnection (obj1, obj2);
	}

	public bool IsValidShip() {
		return shipGraph.AllModulesConnected ();
	}	

	public bool IsConnectedToShip(GameObject obj) {
		return shipGraph.ModuleConnected(obj);
	}

	public void PrepareShipForLevelLoad() {

		Dictionary<GameObject, IList<GameObject>> graph = shipGraph.Graph;

		foreach (GameObject key in graph.Keys) {
			foreach (GameObject value in graph[key]) {
				JointScript.Attach(key, value);
			}

			key.collider.isTrigger = false;
			Destroy (key.GetComponent<ShipEditorScript>());
			DontDestroyOnLoad (key);
			if (key.tag == "Engine") {
				Debug.Log ("Adding engine script..");
				key.AddComponent<ThrusterScript>();
			}
		}
		Application.LoadLevel ("level1");
	}


	public void Update() {
		shipGraph.CalculateConnections ();
	}

}
