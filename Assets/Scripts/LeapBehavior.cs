using UnityEngine;
using System.Collections;
using Leap;

public class LeapBehavior : MonoBehaviour {
	Controller controller;
	
	void Start ()
	{
		controller = new Controller();
	}
	
	void Update ()
	{
		Frame frame = controller.Frame();
		// do something with the tracking data in the frame...
		if(frame.Hands.Count>0)
		{
			print("Hi, there.\n");
		}
	}
}
