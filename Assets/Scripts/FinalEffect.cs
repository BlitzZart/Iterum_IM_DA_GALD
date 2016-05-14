using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.Characters.FirstPerson;

public class FinalEffect : MonoBehaviour {
    Bloom bloom;
    bool fadeToWhite = false;

    float fadeTime = 13;
    float currentTime = 0;


    float intensity_a;
    float threshold_a;

    float intensity_b = 7;
    float threshold_b = 0;

    // Use this for initialization
    void Start () {
	
	}


    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            FirstPersonController fpsC = other.GetComponent<FirstPersonController>();
            if (fpsC != null) {
                fpsC.SlowSpeed(0.5f);
            }
            bloom = Camera.main.GetComponent<Bloom>();
            if (bloom != null) {
                intensity_a = bloom.bloomIntensity;
                threshold_a = bloom.bloomThreshold;
                fadeToWhite = true;
            }
        }
    }

    // Update is called once per frame
    void Update () {
	    if (fadeToWhite) {
            bloom.bloomIntensity = Mathf.Lerp(intensity_a, intensity_b, currentTime);
            bloom.bloomThreshold = Mathf.Lerp(threshold_a, threshold_b, currentTime);

            currentTime += Time.deltaTime / fadeTime;

            if (currentTime > fadeTime*2)
                Time.timeScale = 0;
        }
	}
}
