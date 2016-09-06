using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class SliderCube : MonoBehaviour {

    private GameObject player;
    private EdgeDetection edgeDetection;
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
        if (player == null)
            return;

        float value = 0;

        if (min.bounds.Contains(player.transform.position)) {
            value = 0;
        }
        else if (max.bounds.Contains(player.transform.position)) {
            value = 1;
        }
        else if (coll.bounds.Contains(player.transform.position)) {
           value = Mathf.Clamp01(Vector3.Distance(player.transform.position, zeroPoint.position) / transform.localScale.z);
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