using UnityEngine;
using System.Collections;

public class ActivateWall : MonoBehaviour {
    public GameObject wall1, wall2;

    void OnTriggerEnter(Collider other) {
        wall1.SetActive(true);
        wall2.SetActive(true);
    }


    // Update is called once per frame
    void Update () {
	
	}
}
