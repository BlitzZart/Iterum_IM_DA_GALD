using UnityEngine;
using System.Collections;

public class FadeInOut : MonoBehaviour {
    public Color fadeColor;

    private float transitionDuration = 1;

    // Use this for initialization
    public void FadeIn (float duration) {
        //iTween.CameraFadeAdd(iTween.CameraTexture(fadeColor));
        ////iTween.CameraFadeTo(1, transitionDuration);
        //iTween.CameraFadeAdd(iTween.CameraTexture(fadeColor));
        //iTween.CameraFadeTo(1, transitionDuration);
    }

	// Update is called once per frame
	void Start () {
        print("START");
        iTween.CameraFadeAdd(iTween.CameraTexture(fadeColor));
        iTween.CameraFadeTo(1, transitionDuration);

    }
}
