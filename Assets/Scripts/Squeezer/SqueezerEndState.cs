using UnityEngine;
using System.Collections;

public class SqueezerEndState : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }
    void MsgPlayerEntered(GameObject player) {
        SqueezeWall[] walls = FindObjectsOfType<SqueezeWall>();

        foreach(SqueezeWall wall in walls) {
            wall.DeActivate();
        }

        // push back wall
        walls[1].transform.Translate(0, -2, 0);
    }
}