using UnityEngine;
using System.Collections.Generic;

public class ShipDamageScript : MonoBehaviour {
	private int health;
	private const int DAMAGE_IMMUNITY_TIME = 30; // immunity in frames
	private int immunityRemaining;

	// Use this for initialization
	void Start () {
		immunityRemaining = 0;
		health = 3;
	}

	public void TakeDamage() {
		if (immunityRemaining == 0) {
			immunityRemaining = DAMAGE_IMMUNITY_TIME;
			--health;		
		}

		if (health == 0) {
			var shipScript = Utility.GetShipScript();
			var graph = shipScript.GetShipGraph();

			// cannot iterate over list when it is being modified; must copy the objects into separate list
			var attachedObjects= new List<GameObject>(graph[gameObject]);
			foreach (GameObject attachedObject in attachedObjects) {
				JointScript.Detach(gameObject, attachedObject);
				shipScript.RemoveConnection(gameObject, attachedObject);
			}


		}
	}
	
	// Update is called once per frame
	void Update () {
		if (immunityRemaining > 0) {
			--immunityRemaining;		
		}
	}
}
