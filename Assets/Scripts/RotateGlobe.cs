using UnityEngine;
using System.Collections;

public class RotateGlobe : MonoBehaviour {

    public float rotationSpeed = 1.7f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
	}
}
