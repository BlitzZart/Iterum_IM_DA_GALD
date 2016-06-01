using UnityEngine;
using System.Collections;

public class SqueezerEndState : MonoBehaviour {

    public SqueezeWall wallStart, wallAhead;

    private bool doneOnce = false;

    // Use this for initialization
    void Start() {

    }
    void MsgPlayerEntered(GameObject player) {
        //SqueezeWall[] walls = FindObjectsOfType<SqueezeWall>();
        //foreach(SqueezeWall wall in walls) {
        //    wall.DeActivate();
        //}

        // push back wall
        if (doneOnce)
            return;

        doneOnce = true;
        wallStart.DeActivate();
        wallAhead.DeActivate();

        wallAhead.transform.Translate(0, -4, 0);
    }
}