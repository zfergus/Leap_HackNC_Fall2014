using UnityEngine;
using System.Collections;

public class BattToBuld : MonoBehaviour {

	public float breakForce = 10.0f;
	public float breakTorque = 10.0f;
	//public Light light;
	public bool connected, onTile;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Light>().intensity = 0;
		this.connected = false; 
		this.onTile = false;
	}

	void Update()
	{
		if (connected)
			this.gameObject.GetComponent<Light>().intensity = 1.0f;
		else if(!onTile){
			this.gameObject.GetComponent<Light>().intensity = 0.0f;
		}
	}

	void OnCollisionStay(Collision col)
	{
		if (col.gameObject.tag == "batt")
		{
			foreach (ContactPoint contact in col.contacts) 
			{
					Debug.DrawRay (contact.point, contact.normal, Color.white);
			}
			SpringJoint spring = GetComponent<SpringJoint> ();       
			if (spring != null)
				Destroy (spring);
			FixedJoint head_joint = gameObject.AddComponent<FixedJoint> ();
			head_joint.breakForce = breakForce;
			head_joint.breakTorque = breakTorque;
			this.gameObject.GetComponent<Light>().intensity = 1;
			this.connected = true;
			this.onTile = false;
		} 
		else if (col.gameObject.tag == "tile") 
		{
			this.onTile = true;
		}
		else 
		{
			this.connected = false;
			this.onTile = false;
		}
	}
}