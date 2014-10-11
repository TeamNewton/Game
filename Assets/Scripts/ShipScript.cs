using UnityEngine;
using System.Collections.Generic;

public class ShipScript  : MonoBehaviour{

	ShipGraph shipGraph;

	public void Start() {

	}

	// move ship to start pos
	void OnLevelWasLoaded(int level) {
		Debug.Log ("Level loaded!");		

		var commandModule = GameObject.FindGameObjectWithTag ("Command");
		var commandPosition = commandModule.transform.position;
		var startPos = GameObject.FindGameObjectWithTag ("StartPos");

		foreach (GameObject o in shipGraph.Graph.Keys) {
			var relativePosition = commandPosition - o.transform.position;
			Debug.Log ("Relative: " + relativePosition); 
			o.transform.position = startPos.transform.position - relativePosition;
		}
	}

	public Dictionary<GameObject, IList<GameObject>> GetShipGraph() {
		return shipGraph.Graph;
	}

	public void SetConnectableObjects(List<GameObject> objects) {
		shipGraph = new ShipGraph();
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


	public float RemainingFuel() {
		var fuelTanks = shipGraph.GetConnectedModulesWithTag ("FuelTank");
		float fuelRemaining = 0;
		
		foreach (GameObject tank in fuelTanks) {
			var script = tank.GetComponent<FuelTankScript>();
			fuelRemaining += script.Fuel;
		}

		return fuelRemaining;
	}

	// returns false if there wasn't enough fuel to consume and does not consume the fuel
	// otherwise consumes the fuel and returns true
	public bool ConsumeFuelIfEnough(float amount) {
		var fuelTanks = shipGraph.GetConnectedModulesWithTag ("FuelTank");

		float fuelRemaining = RemainingFuel ();
		Debug.Log ("Fuel remaining: " + fuelRemaining);

		if (fuelRemaining <= amount) {
			return false;
		}

		foreach (GameObject tank in fuelTanks) {
			var script = tank.GetComponent<FuelTankScript>();
			script.ConsumeFuel(amount/fuelTanks.Count);
		}
		return true;
	}

	public void Update() {
		shipGraph.CalculateConnections ();
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
				key.AddComponent<ThrusterScript>();
			}
		}
	}

}
