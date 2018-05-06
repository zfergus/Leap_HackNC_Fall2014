using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Saving screenshot.");
            ScreenCapture.CaptureScreenshot(Application.dataPath + "/screenshot.png", 4);
        }
    }
}
