using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum SwitchType {
    OnSwitch, OffSwitch, FlipSwitch
}

public class UniversalSwitch : MonoBehaviour {

    public SwitchType type = SwitchType.OnSwitch;

    public List<GameObject> objects;
    private List<ISwitchable> switchables;

    void Start() {
        switchables = new List<ISwitchable>();
        foreach (GameObject item in objects) {
            ISwitchable switchable = item.GetComponent<ISwitchable>();
            if (switchable != null)
                switchables.Add(switchable);
        }
    }


    void OnTriggerEnter(Collider other) {
        foreach (ISwitchable go in switchables) {
            if (type == SwitchType.OnSwitch)
                go.Activate();
            else if (type == SwitchType.OffSwitch)
                go.DeActivate();
            else if (type == SwitchType.FlipSwitch)
                go.Switch();
        }
    }
}
