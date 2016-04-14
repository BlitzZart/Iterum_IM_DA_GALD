using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    public GameObject start, goal;

    void TeleporterEntered(GameObject player) {
        player.gameObject.transform.position = goal.transform.position;
    }
}
