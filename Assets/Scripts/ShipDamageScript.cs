using UnityEngine;
using System.Collections;

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
			var graph = Utility.GetShipScript().GetShipGraph();

			foreach (GameObject attachedObject in graph[gameObject]) {
				JointScript.Detach(gameObject, attachedObject);
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
