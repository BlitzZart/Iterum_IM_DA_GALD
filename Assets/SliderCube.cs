using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.VR;

public class SliderCube : MonoBehaviour {

    private GameObject player;
    public EdgeDetection edgeDetection;
    private Collider coll;

    public Transform zeroPoint;
    public Collider min;
    public Collider max;
    // Use this for initialization
    void Start() {
        edgeDetection = Camera.main.GetComponent<EdgeDetection>();
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update() {
        if (player == null || edgeDetection == null)
            return;

        float value = 0;

        if (min.bounds.Contains(player.transform.position)) {
            value = 0;
            edgeDetection.sampleDist = 0;
            //print(">> 0 " + name);
        }
        else if (max.bounds.Contains(player.transform.position)) {
            value = 1;
            edgeDetection.sampleDist = 1;
            //print(">> 1 " + name);
        }
        else /*if (coll.bounds.Contains(player.transform.position))*/ {
            value = Mathf.Clamp01(Vector3.Distance(player.transform.position, zeroPoint.position) / transform.localScale.z);
            if (value > 0.051f)
                edgeDetection.sampleDist = 1;
            else {
                edgeDetection.sampleDist = 0;
            }
            //print(">> " + value + name);
        }

        edgeDetection.edgesOnly = value;



        //edgeDetection.edgesOnly = Mathf.Lerp(edgeDetection.edgesOnly, value, Time.deltaTime * 100);
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