using UnityEngine;
using System.Collections;
using System;

public class LightSwitch : MonoBehaviour, ISwitchable {

    private Light[] lights;
    // Use this for initialization
    void Start() {
        lights = GetComponentsInChildren<Light>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void SetEnabled(bool val) {
        for (int i = 0; i < lights.Length; i++) {
            lights[i].enabled = val;
        }
    }

    public void Activate() {
        SetEnabled(true);
    }

    public void DeActivate() {
        SetEnabled(false);
    }

    public bool GetState() {
        if (lights.Length < 0)
            return false;
        return lights[0].enabled;
    }

    public void Switch() {
        if (lights.Length < 1)
            return;
        for (int i = 0; i < lights.Length; i++) {
            lights[i].enabled = !lights[i].enabled;
        }
    }
}
