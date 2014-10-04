using UnityEngine;
using System.Collections;

public class JointScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public static void attach(GameObject obj1, GameObject obj2)
	{

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

	public static void detach(GameObject obj1,GameObject obj2) 
	{
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
		joints = obj2.GetComponents<ConfigurableJoint> ();
		if(joints != null) 
		{
			foreach(ConfigurableJoint c in joints)
			{
				if(c.connectedBody == obj1.GetComponent<Rigidbody>())
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
