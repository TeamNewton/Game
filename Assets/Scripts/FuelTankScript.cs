using UnityEngine;
using System.Collections;

public class FuelTankScript : MonoBehaviour {

	// engine consumes n units of fuel per single fixed update 
	// (default every 20ms)
	// so this should be scaled using that
	private const float maxFuelCapacity = 50*20; // using default time step, enough fuel for 20 seconds for singe engine
	private float currentCapacity;

	// Use this for initialization
	void Start () {
		currentCapacity = maxFuelCapacity;
	}

	public float MaxFuel {
		get { return maxFuelCapacity; }
	}

	public float Fuel {
		get { return currentCapacity; }
	}
	
	public void ConsumeFuel(float amount) {
		currentCapacity -= amount;
		if (currentCapacity < 0) {
			currentCapacity = 0;
		}
	}

}
