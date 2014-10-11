
using UnityEngine;
using System.Collections.Generic;

public class Utility {

	public static GameObject FindNearestBodyWithTag(string tag, GameObject gameObject) {
		float distance = Mathf.Infinity;
		GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
		GameObject nearestObj = null;

		foreach (GameObject obj in objects) {

			var objectPos = obj.transform.position;
			float newDistance = (objectPos - gameObject.transform.position).sqrMagnitude;
			
			if (newDistance < distance) {
				nearestObj = obj;
				distance = newDistance;
			}
		}

		return nearestObj;
	}


	public static List<GameObject> GetGameObjects() {

		var gameObjects = new List<GameObject>();
		
		AddObjectsWithTag(gameObjects, "Command");
		AddObjectsWithTag(gameObjects, "VehicleBody");
		AddObjectsWithTag(gameObjects, "Engine");
		AddObjectsWithTag(gameObjects, "FuelTank");

		return gameObjects;
	}

	public static void RegisterConnection(GameObject obj, GameObject obj2) {
		ShipScript script = GetShipScript ();
		if (script != null) {
			script.AddConnection (obj, obj2);
		}
	}

	public static void UnregisterConnection(GameObject obj, GameObject obj2) {
		ShipScript script = GetShipScript ();
		if (script != null) {
			script.RemoveConnection (obj, obj2);
		}
	}


	public static bool ShipIsValid() {
		ShipScript script = GetShipScript ();
		if (script != null) {
			return script.IsValidShip();
		}

		return false;

	}

	public static void InitializeShipGraph() {
		ShipScript script = GetShipScript ();
		if (script != null) {
			List<GameObject> gameObjects = GetGameObjects();

			script.SetConnectableObjects(gameObjects);
		}
	}

	private static void AddObjectsWithTag(List<GameObject> gameObjects, string tag) {
		GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
		gameObjects.AddRange (objects);	
	}

	public static ShipScript GetShipScript() {
		GameObject[] objects = GameObject.FindGameObjectsWithTag("Command");
		if (objects.Length == 0) {
			return null;		
		}

		return objects[0].GetComponent<ShipScript>();
	}






}