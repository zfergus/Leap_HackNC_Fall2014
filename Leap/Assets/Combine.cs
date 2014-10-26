using UnityEngine;
using System.Collections;

//namespace Connect.Together
//{
//	[RequireComponent(typeof(Rigidbody))]
//	[RequireComponent(typeof(Collider))]
	public class ConnectTogether : MonoBehaviour {
		
		public float breakForce = 10.0f;
		public float breakTorque = 10.0f;
		
		void OnCollisionEnter(Collision collision) {
			foreach (ContactPoint contact in collision.contacts) {
				Debug.DrawRay(contact.point, contact.normal, Color.white);
			}
			if (collision.gameObject.name == "Cube") {
				SpringJoint spring = GetComponent<SpringJoint>();       
				if (spring != null)
					Destroy(spring);
				FixedJoint head_joint = gameObject.AddComponent<FixedJoint>();
				head_joint.breakForce = breakForce;
				head_joint.breakTorque = breakTorque;
			}
			
		}
		
		void Start () {
		}
		void Update () {
		}
	}
//}
/*

using UnityEngine;
using System.Collections;

namespace Connect.Together
{
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(Collider))]

namespace Connect.Together
{
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(Collider))]
public class Combine : MonoBehaviour
{
	public float breakForce = 10.0f;
	public float breakTorque = 10.0f;
	
	void OnCollisionEnter(Collision collision) {
		foreach (ContactPoint contact in collision.contacts) {
			Debug.DrawRay(contact.point, contact.normal, Color.white);
		}
		if (collision.gameObject.name == "Cube") {
			SpringJoint spring = GetComponent<SpringJoint>();       
			if (spring != null)
				Destroy(spring);
			FixedJoint head_joint = gameObject.AddComponent<FixedJoint>();
			head_joint.breakForce = breakForce;
			head_joint.breakTorque = breakTorque;
	}
	void OnCollisionEnter (Collision col)
	{
		col.transform.parent = transform;
		//if(col.gameObject.name == "Cube")
		//{
			GameObject object1 = col.gameObject;
			GameObject object2 = this;
			// Disable collisions with the object being attached
			if(object1.collider2D)
			{
				7object1.collider2D.enabled = fal}se;
			}
		
			// Don't allow physics to affect the object
			if(object1.rigidbody2D)
			{
				object1.rigidbody2D.isKinematic = true;
			}
		
			// Attach object 1 to object 2
			object1.transform.parent = object2.transform;
			
			// Center object 1 on object 2 (no offset)
			object1.transform.localPosition = Vector3.zero;
	}
}
*/