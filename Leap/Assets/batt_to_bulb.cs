using UnityEngine;
using System.Collections;

public class batt_to_bulb : MonoBehaviour {

	public float breakForce = 10.0f;
	public float breakTorque = 10.0f;
	//public Light light;
	public bool connected;

	// Use this for initialization
	void Start () {
		gameObject.light.intensity = 0;
			connected = false;
	}

	void Update()
	{
		if (connected)
			gameObject.light.intensity = 1.0f;
		else {
			gameObject.light.intensity = 0.0f;
		}
	}
	
	// Update is called once per frame
	void OnCollisionStay(Collision collision)
	{
		//bool result = collision.gameObject.GetType().IsAssignableFrom(new Tile().GetType());
		//Tile t = (Tile)collision.gameObject;
		if (collision.gameObject.name == "batt") {
			foreach (ContactPoint contact in collision.contacts) {
				Debug.DrawRay (contact.point, contact.normal, Color.white);
			}
			SpringJoint spring = GetComponent<SpringJoint> ();       
			if (spring != null)
					Destroy (spring);
			FixedJoint head_joint = gameObject.AddComponent<FixedJoint> ();
			head_joint.breakForce = breakForce;
			head_joint.breakTorque = breakTorque;
			gameObject.light.intensity = 1;
			connected = true;
		}
//		else if(collision.gameObject.name == "tile" && collision.gameObject.light.intensity > 0){
//			SpringJoint spring = GetComponent<SpringJoint> ();       
//			if (spring != null)
//				Destroy (spring);
//			FixedJoint head_joint = gameObject.AddComponent<FixedJoint> ();
//			head_joint.breakForce = breakForce;
//			head_joint.breakTorque = breakTorque;
//			gameObject.light.intensity = 1;
//			connected = true;
//		}
		else {
			connected = false;
		}
		
		//else if(result && t.charged)
		//{
		/*	foreach (ContactPoint contact in collision.contacts){
				Debug.DrawRay(contact.point, contact.normal, Color.white);
			}
			SpringJoint spring = GetComponent<SpringJoint> ();       
			if (spring != null)
				Destroy (spring);
			FixedJoint head_joint = gameObject.AddComponent<FixedJoint> ();
			head_joint.breakForce = breakForce;
			head_joint.breakTorque = breakTorque;
			gameObject.light.intensity = 1;
		}*/
	}
}
