using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.ImageEffects;

public class SlowPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            FirstPersonController fpsC = other.GetComponent<FirstPersonController>();
            if (fpsC != null) {
                fpsC.SlowSpeed(2);
            }

            Bloom bloom = Camera.main.GetComponent<Bloom>();
            if (bloom != null) {
                bloom.enabled = true;
            }
        }
    }
}
