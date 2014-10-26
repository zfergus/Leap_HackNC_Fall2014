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
		intense = 20.0f; 
		resistance = 1.0f;
		charged = false;
		go = null;
	}

	// Update is called once per frame
	void Update (){
		if (charged) {
			gameObject.light.intensity = 0.01f;
			if (go!=null){ go.light.intensity = intense * resistance; }
		} 
		else {
			gameObject.light.intensity = 0.0f;
			if(go!=null){ go.light.intensity = 0.0f; }
		}
	}

	void OnCollisionStay(Collision col)
	{
		if (col.gameObject.name == "resis") {
			resistance = 0.1f;
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
		else if (col.gameObject.name == "bulb" && charged) {
			if(go != null){go.light.intensity = 0.0f;}
			col.gameObject.light.intensity = intense * resistance;
			go = col.gameObject;
		} 
		else {
			charged = false;
			if(col.gameObject.name == "bulb"){ col.gameObject.light.intensity = 0.0f; }
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
}