using UnityEngine;
using System.Collections;

public class DeactivateWall : MonoBehaviour {

    public GameObject wall1, wall2;

    void OnTriggerEnter(Collider other) {
        wall1.SetActive(false);
        wall2.SetActive(false);
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
