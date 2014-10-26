using UnityEngine;
using System.Collections;

public class tile_charge : MonoBehaviour {

	//Light light;
	bool charged;
	public float intense, resistance;
	GameObject go;

	// Use this for initialization
	void Start () {
		//rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
		intense = 10.0f; 
		resistance = 1.0f;
		charged = false;
	}

	// Update is called once per frame
	void Update (){
		if (charged) {
			gameObject.light.intensity = 0.1f;
			if (go!=null){ go.light.intensity = intense * resistance; }
		} 
		else {
			gameObject.light.intensity = 0.0f;
			if(go!=null){ go.light.intensity = 0.0f; }
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "resis") {
			resistance = 0.5f;
		}
		else if (col.gameObject.name == "resis2") {
			resistance = 0.75f;
		}

//		resistance = col.gameObject.name == "resis" ? 0.1f : 1.0f;

//		if (col.gameObject.name == "batt") {
//			charged = true;
//		}
//		else{
//			charged = false;
//		}
		else if (col.gameObject.name == "batt") {
			charged = true;
		}
		else if (col.gameObject.name == "bulb" && charged == true) {
			go = col.gameObject;
			go.light.intensity = intense * resistance;
		} 
		else {
			charged = false;
			resistance = 1.0f;
		}
//		else if (col.gameObject.name == "floor" || col.gameObject.name == "bulb") {
//			charged = charged;		
//		}
//		else if(col.gameObject.name == "tile" && col.gameObject.light.intensity > 0) {
//			gameObject.light.intensity = 0.01f;
//		}
//		else if(col.gameObject.name == "bulb" && gameObject.light.intensity > 0) {
//			col.gameObject.light.intensity =1.0f;	
//		}
	}
	void OnCollisionExit(Collision col)
	{
		if (col.gameObject.name == "batt") {
			charged = false;
			if(go != null){go.light.intensity = 0.0f;}
		}
		else if (col.gameObject.name == "resis" || col.gameObject.name == "resis2") {
			resistance = 1.0f;
		}
	}
}