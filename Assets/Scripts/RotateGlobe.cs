using UnityEngine;
using System.Collections;

public class RotateGlobe : MonoBehaviour {

    public float rotationSpeed = 1.7f;

    private SphereCollider sc;

	// Use this for initialization
	void Start () {
        sc = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
	}
}
