using UnityEngine;
using System.Collections;

public class ShipDamageScript : MonoBehaviour {
	private int health;
	private const int DAMAGE_IMMUNITY_TIME = 30; // immunity in frames
	private int immunityRemaining;

	// Use this for initialization
	void Start () {
		immunityRemaining = 0;
		health = 10;
	}

	public void TakeDamage() {
		if (immunityRemaining == 0) {
			--health;		
		}

		if (health == 0) {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (immunityRemaining > 0) {
			--immunityRemaining;		
		}
	}
}
