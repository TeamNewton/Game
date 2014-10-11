using UnityEngine;
using System.Collections.Generic;

public class ShipGraph {

	private Dictionary<GameObject, IList<GameObject>> shipGraph;
	private Dictionary<GameObject, bool> connectedToCommandModule;


	public Dictionary<GameObject, IList<GameObject>> Graph {
		get { return shipGraph; }
	}

	public void Initialize(IList<GameObject> objects) {
		shipGraph = new Dictionary<GameObject, IList<GameObject>> ();
		connectedToCommandModule = new Dictionary<GameObject, bool> ();

		foreach (GameObject obj in objects) {
			shipGraph.Add (obj, new List<GameObject>());
			connectedToCommandModule.Add(obj, false);
		}
	}


	public void AddConnection(GameObject obj1, GameObject obj2) {
		AddConnectionPair (obj1, obj2);
		AddConnectionPair (obj2, obj1);
	}

	private void AddConnectionPair(GameObject key, GameObject value) {
		if (!shipGraph[key].Contains(value)) {
			shipGraph[key].Add(value);
		}	
	}

	
	public void RemoveConnection(GameObject obj1, GameObject obj2) {
		RemoveConnectionPair (obj1, obj2);
		RemoveConnectionPair (obj2, obj1);
	}
	
	private void RemoveConnectionPair(GameObject key, GameObject value) {
		if (shipGraph.ContainsKey (key)) {
			shipGraph[key].Remove(value);
		}
	}

	public void CalculateConnections() {

		// modifying collection while iterating over keys directly causes runtime error
		// hence why we must create new list from the keys
		var keys = new List<GameObject>(connectedToCommandModule.Keys);

		foreach (GameObject obj in keys) {
			connectedToCommandModule[obj] = false;
		} 
		
		// find the initial module (command module) where we start the search
		GameObject[] objects = GameObject.FindGameObjectsWithTag("Command");
		if (objects.Length == 0) {
			return;		
		}
		
		Queue<GameObject> queue = new Queue<GameObject> ();
		queue.Enqueue(objects [0]);
		connectedToCommandModule[objects[0]] = true;
				
		
		while (queue.Count > 0) {
			GameObject node = queue.Dequeue();
			foreach (GameObject obj in shipGraph[node]) {
				if (connectedToCommandModule[obj] == false) {
					queue.Enqueue (obj);
					connectedToCommandModule[obj] = true;
				}
			}
		}
	}

	public bool AllModulesConnected() {
		foreach (GameObject obj in connectedToCommandModule.Keys) {
			if (connectedToCommandModule[obj] == false) {
				return false;
			}
		}
		return true;
	}

	public bool ModuleConnected(GameObject obj) {
		return connectedToCommandModule[obj];
	}

	public List<GameObject> GetConnectedModulesWithTag(string tag) {
		List<GameObject> modules = new List<GameObject>();

		foreach (GameObject obj in connectedToCommandModule.Keys) {
			if (connectedToCommandModule[obj] == true && obj.tag == tag) {
				modules.Add (obj);
			}
		} 

		return modules;
	}


}
