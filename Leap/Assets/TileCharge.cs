using UnityEngine;
using System.Collections;

public class TileCharge : MonoBehaviour
{

	bool charged;
	public float intense, resistance;
	GameObject go;

	// Use this for initialization
	void Start ()
	{
		this.intense = 10.0f; 
		this.resistance = 1.0f;
		this.charged = false;
		this.go = null;
	}

	// Update is called once per frame
	void Update ()
	{
		if (this.charged)
		{
			this.gameObject.GetComponent<Light>().intensity = 0.1f;
			if(this.go!=null)
			{ 
				this.go.GetComponent<Light>().intensity = intense * resistance;
			}
		} 
		else
		{
			this.gameObject.GetComponent<Light>().intensity = 0.0f;
			if(this.go!=null)
			{
				go.GetComponent<Light>().intensity = 0.0f;
			}
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "resis")
		{
			this.resistance = 0.5f;
		}
		else if (col.gameObject.tag == "resis2")
		{
			this.resistance = 0.75f;
		}
		else if (col.gameObject.tag == "batt")
		{
			this.charged = true;
		}
		else if (col.gameObject.tag == "bulb" && this.charged)
		{
			this.go = col.gameObject;
			this.go.GetComponent<Light>().intensity = intense * resistance;
		} 
		else
		{
			this.charged = false;
			this.resistance = 1.0f;
		}
	}
	
	void OnCollisionExit(Collision col)
	{
		if (col.gameObject.tag == "batt")
		{
			this.charged = false;
			if(this.go != null)
			{
				this.go.GetComponent<Light>().intensity = 0.0f;
			}
		}
		else if (col.gameObject.tag == "resis" || 
				 col.gameObject.tag == "resis2")
		{
			this.resistance = 1.0f;
		}
	}
}