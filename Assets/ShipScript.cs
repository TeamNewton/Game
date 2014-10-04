using UnityEngine;
using System.Collections.Generic;

public class ShipScript  : MonoBehaviour{

	private Dictionary<GameObject, IList<GameObject>> shipGraph;

	// Use this for initialization
	void Start () {

	
	}

	public void SetConnectableObjects(List<GameObject> objects) {
		shipGraph = new Dictionary<GameObject, IList<GameObject>> ();
		foreach (GameObject obj in objects) {
			shipGraph.Add (obj, new List<GameObject>());
		}	
	}

	public void AddConnection(GameObject obj, GameObject obj2) {
		AddConnectionPair (obj, obj2);
		AddConnectionPair (obj2, obj);
	}

	private void AddConnectionPair(GameObject key, GameObject value) {
		if (!shipGraph[key].Contains(value)) {
			shipGraph[key].Add(value);
		}	
	}

	public void RemoveConnection(GameObject obj, GameObject obj2) {
		RemoveConnectionPair (obj, obj2);
		RemoveConnectionPair (obj2, obj);
	}

	private void RemoveConnectionPair(GameObject key, GameObject value) {
		if (shipGraph.ContainsKey (key)) {
			shipGraph[key].Remove(value);
		}
	}


	// TODO: Extract the bfs to separate file in order to increase clarity
	public bool IsValidShip() {
		// initialize discovery graph to false
		Dictionary<GameObject, bool> discoveredObjects = new Dictionary<GameObject, bool>();

		foreach (GameObject obj in shipGraph.Keys) {
			discoveredObjects.Add(obj, false);
		} 

		// find the initial module (command module) where we start the search
		GameObject[] objects = GameObject.FindGameObjectsWithTag("Command");
		if (objects.Length == 0) {
			return false;		
		}
		
		Queue<GameObject> queue = new Queue<GameObject> ();
		queue.Enqueue(objects [0]);


		while (queue.Count > 0) {
			GameObject node = queue.Dequeue();
			foreach (GameObject obj in shipGraph[node]) {
				if (discoveredObjects[obj] == false) {
					queue.Enqueue (obj);
				}
			}			

			discoveredObjects[node] = true;
		}

		foreach (bool discoveryStatus in discoveredObjects.Values) {
			if (discoveryStatus == false) {
				return false;
			}
		}

		return true;
	}	

	public void AddJoints() {
		foreach (GameObject key in shipGraph.Keys) {
			foreach (GameObject value in shipGraph[key]) {
				JointScript.Attach(key, value);
			}
		} 

	}

}
