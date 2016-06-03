using UnityEngine;
using System.Collections;
using System;

public class MeshRenderSwitch : MonoBehaviour, ISwitchable {

    private MeshRenderer[] renderers;
    // Use this for initialization
    void Start() {
        renderers = GetComponentsInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void SetEnabled(bool val) {
        for (int i = 0; i < renderers.Length; i++) {
            renderers[i].enabled = val;
        }
    }

    public void Activate() {
        SetEnabled(true);
    }

    public void DeActivate() {
        SetEnabled(false);
    }

    public bool GetState() {
        if (renderers.Length < 0)
            return false;
        return renderers[0].enabled;
    }

    public void Switch() {
        if (renderers.Length < 1)
            return;
        for (int i = 0; i < renderers.Length; i++) {
            renderers[i].enabled = !renderers[i].enabled;
        }
    }
}
