using UnityEngine;
using System.Collections;

public class ScreenShooter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update() {
        if (Input.GetMouseButtonDown(0)) {
            print("Knips");
            Application.CaptureScreenshot("Screenshot.png", 2);
        }

	}
}
