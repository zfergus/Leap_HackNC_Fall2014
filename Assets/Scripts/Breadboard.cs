using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Breadboard : MonoBehaviour
{
	private int charged;
	private ArrayList connectedLights;

    public float intensity = 10.0f;
    public int lightCount = 0;
    private float resistance;

	// Use this for initialization
	void Start ()
	{
        this.resistance = 1.0f;
		this.charged = 0;
		this.connectedLights = new ArrayList();
	}

	// Update is called once per frame
	void UpdateLights()
	{
        for(int i = 0; i < this.connectedLights.Count; i++)
        {
            GameObject light = (GameObject)this.connectedLights[i];
            light.GetComponent<Light>().intensity = this.charged * this.intensity * this.resistance;
        }
        this.lightCount = this.connectedLights.Count;
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "resistor")
		{
			this.resistance *= col.gameObject.GetComponent<Resistor>().resistance;
		}
		else if (col.gameObject.tag == "battery")
		{
			this.charged = 1;
		}
		else if (col.gameObject.tag == "led")
		{
			this.connectedLights.Add(col.gameObject);
		} 
		else
		{
            return;
		}
        this.UpdateLights();
	}
	
	void OnCollisionExit(Collision col)
	{
        if (col.gameObject.tag == "resistor")
        {
            this.resistance /= col.gameObject.GetComponent<Resistor>().resistance;
        }
        else if (col.gameObject.tag == "battery")
        {
            this.charged = 0;
        }
        else if (col.gameObject.tag == "led")
        {
            col.gameObject.GetComponent<Light>().intensity = 0;
            this.connectedLights.Remove(col.gameObject);
        }
        else
        {
            return;
        }
        this.UpdateLights();
    }
}