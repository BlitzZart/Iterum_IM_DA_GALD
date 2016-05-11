using UnityEngine;
using System.Collections;
using Triggers;

public class RotateStair : MonoBehaviour {
    public int runingCW = 180;
    public int runingCCW = 90;

    public GameObject wall;

    void Start() {

    }

    void TriggerChanged(TriggerType changedTo) {
        if (changedTo == TriggerType.A) { // CCW
            wall.transform.Rotate(0, runingCW, 0, Space.Self);
        }
        else if (changedTo == TriggerType.B) { // CW
            wall.transform.Rotate(0, runingCCW, 0, Space.Self);
        }
    }
}
