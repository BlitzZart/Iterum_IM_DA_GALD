using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class FinalLookUp : MonoBehaviour {
    private Hashtable ht = new Hashtable();
    private float height = 13;
    private float lerpSpeed = 1;
    private bool lookUp = false;

    private Vector3 playerPos;
    private Transform cam;

    // Use this for initialization
    void Start() {
        ht.Add("x", transform.position.x);
        ht.Add("y", transform.position.y);
        ht.Add("z", transform.position.z);
        ht.Add("easeType", iTween.EaseType.easeInOutExpo);
    }

    public void StartMoving(FirstPersonController fpsC, float speed) {
        ht.Add("time", speed);

        if (fpsC != null) {
            lookUp = true;
            fpsC.enabled = false;
            playerPos = fpsC.transform.position;
            cam = Camera.main.transform;
        }

        iTween.MoveTo(gameObject, transform.position + Vector3.up * height, speed * 20);
    }
	
	// Update is called once per frame
	void Update () {
        if (lookUp) {
            Quaternion hardLook = Quaternion.LookRotation(transform.position - playerPos);

            cam.rotation = Quaternion.Lerp(cam.rotation, hardLook, lerpSpeed * Time.deltaTime);
        }
	}
}
