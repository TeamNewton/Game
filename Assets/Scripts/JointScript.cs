using UnityEngine;
using System.Collections;

public class JointScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public static void Attach(GameObject obj1, GameObject obj2)
	{
		// obj1 and obj2 should have max 1 joint between them; remove any existing joints before adding new
		Detach (obj1, obj2);

		ConfigurableJoint joint = obj1.AddComponent<ConfigurableJoint>();

		joint.connectedBody = obj2.GetComponent<Rigidbody>();

		joint.autoConfigureConnectedAnchor = true;

		joint.xMotion = ConfigurableJointMotion.Locked;
		joint.yMotion = ConfigurableJointMotion.Locked;
		joint.zMotion = ConfigurableJointMotion.Locked;

		joint.angularXMotion = ConfigurableJointMotion.Locked;
		joint.angularYMotion = ConfigurableJointMotion.Locked;
		joint.angularZMotion = ConfigurableJointMotion.Locked;


	}

	public static void Detach(GameObject obj1,GameObject obj2) 
	{
		DetachJointsBetween (obj1, obj2);
		DetachJointsBetween (obj2, obj1);		
	}

	public static void DetachJointsBetween(GameObject obj1, GameObject obj2) {
		ConfigurableJoint[] joints = obj1.GetComponents<ConfigurableJoint> ();
		if(joints != null) 
		{
			foreach(ConfigurableJoint c in joints)
			{
				if(c.connectedBody == obj2.GetComponent<Rigidbody>())
				{
					Destroy (c);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
