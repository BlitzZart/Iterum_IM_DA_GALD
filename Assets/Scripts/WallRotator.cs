﻿using UnityEngine;
using Triggers;

public class WallRotator : MonoBehaviour {

    private int runingCW = 90;
    private int runingCCW = 90;

    public GameObject wall;

    void Start() {

    }

    void TriggerChanged(TriggerType changedTo) {
        if (changedTo == TriggerType.A) { // CCW
            wall.transform.Rotate(0, 0, runingCW, Space.Self);
        }
        else if (changedTo == TriggerType.B) { // CW
            wall.transform.Rotate(0, 0, runingCCW, Space.Self);
        }
    }
}