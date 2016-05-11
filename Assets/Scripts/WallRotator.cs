using UnityEngine;
using Triggers;

public class WallRotator : MonoBehaviour {

    public int runingCW = 180;
    public int runingCCW = 90;

    public GameObject wall;

    void Start() {

    }

    void TriggerChanged(TriggerType changedTo) {
        print("TriggerChanged");
        if (changedTo == TriggerType.A) { // CCW
            wall.transform.Rotate(0, runingCW, 0, Space.Self);
        }
        else if (changedTo == TriggerType.B) { // CW
            wall.transform.Rotate(0, runingCCW, 0, Space.Self);
        }
    }
}