using UnityEngine;
using System.Collections.Generic;

public class ShipScript  : MonoBehaviour{

	ShipGraph shipGraph;

	public void Start() {

	}

	// move ship to start pos
	void OnLevelWasLoaded(int level) {
		var commandPosition = transform.position;
		var startPos = GameObject.FindGameObjectWithTag ("StartPos");

		foreach (GameObject o in shipGraph.Graph.Keys) {
			var relativePosition = commandPosition - o.transform.position;
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

	public float TotalFuel() {
		var fuelTanks = shipGraph.GetConnectedModulesWithTag ("FuelTank");
		float totalFuel = 0;
		
		foreach (GameObject tank in fuelTanks) {
			var script = tank.GetComponent<FuelTankScript>();
			totalFuel += script.MaxFuel;
		}
		
		return totalFuel;
	}

	// returns false if there wasn't enough fuel to consume and does not consume the fuel
	// otherwise consumes the fuel and returns true
	public bool ConsumeFuelIfEnough(float amount) {
		var fuelTanks = shipGraph.GetConnectedModulesWithTag ("FuelTank");

		float fuelRemaining = RemainingFuel ();

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

			key.AddComponent<DamageOnCollisionScript>();
			key.AddComponent<Enforce2DBehaviourScript>();
			DontDestroyOnLoad (key);
			if (key.tag == "Engine") {
				key.AddComponent<ThrusterScript>();
				ThrusterScript thrusterScript = key.GetComponent<ThrusterScript>();
				KeyScript keyScript = key.GetComponent<KeyScript>();

				thrusterScript.setKeyCode(keyScript.key);
				Destroy (keyScript);

			}
		}
	}

}
