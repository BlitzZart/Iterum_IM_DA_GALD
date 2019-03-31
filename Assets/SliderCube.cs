using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class SliderCube : MonoBehaviour {

    private GameObject player;
    private EdgeDetection edgeDetection;
    private Bloom bloom;
    private Collider coll;

    public Transform zeroPoint;
    public Collider min;
    public Collider max;
    // Use this for initialization
    void Start() {
        edgeDetection = Camera.main.GetComponent<EdgeDetection>();
        bloom = Camera.main.GetComponent<Bloom>();
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update() {
        if (player == null)
            return;

        float value = 0;

        if (min.bounds.Contains(player.transform.position)) {
            value = 0;
            edgeDetection.sampleDist = 0;
            edgeDetection.enabled = false;

            //print(">> 0 " + name);
        }
        else if (max.bounds.Contains(player.transform.position)) {
            value = 1;
            edgeDetection.enabled = true;
            edgeDetection.sampleDist = 1;
            //print(">> 1 " + name);
        }
        else /*if (coll.bounds.Contains(player.transform.position))*/ {
            value = Mathf.Clamp01(Vector3.Distance(player.transform.position, zeroPoint.position) / transform.localScale.z);
            if (value > 0.051f)
            {
                edgeDetection.enabled = true;
                edgeDetection.sampleDist = 1;
            }
            else
            {
                edgeDetection.sampleDist = 0;
                edgeDetection.enabled = false;
            }

            //print(">> " + value + name);
        }

        edgeDetection.edgesOnly = value;

        if (value < 0.9f) {
            if (!bloom.enabled)
            {
                bloom.enabled = true;
            }
            bloom.bloomIntensity = 1 - value;
        }
        else
        {
            if (bloom.enabled)
            {
                bloom.bloomIntensity = 0;
                bloom.enabled = false;
            }
        }

        //print(">> " + value);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            player = other.gameObject;
        }
    }
    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            player = null;
        }
    }
}