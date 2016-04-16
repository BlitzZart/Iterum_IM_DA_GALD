using UnityEngine;
using System.Collections;
using System;

public class EnterTeleporter : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            SendMessageUpwards("TeleporterEntered", other.gameObject);
        }
    }
}
