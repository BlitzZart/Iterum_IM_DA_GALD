using UnityEngine;
using System.Collections;

public class TeleportManipulatePlayer : MonoBehaviour {

    void TeleporterEntered(GameObject player)
    {
        Rigidbody body = player.GetComponent<Rigidbody>();

        if (body != null)
        {
            body.velocity = Vector3.zero;
        }

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
