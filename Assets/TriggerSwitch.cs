using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class TriggerSwitch : MonoBehaviour, ISwitchable {

    private List<GameObject> triggers;
    // Use this for initialization
    void Start() {
        triggers = new List<GameObject>();
        PlayerTrigger[] gos = GetComponentsInChildren<PlayerTrigger>();
        foreach (PlayerTrigger item in gos) {
            if (item.GetComponent<PlayerTrigger>() != null) {
                triggers.Add(item.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update() {

    }

    private void SetEnabled(bool val) {
        for (int i = 0; i < triggers.Count; i++) {
            triggers[i].SetActive(val);
        }
    }

    public void Activate() {
        SetEnabled(true);
    }

    public void DeActivate() {
        SetEnabled(false);
    }

    public bool GetState() {
        if (triggers.Count < 0)
            return false;
        return triggers[0].activeSelf;
    }

    public void Switch() {
        if (triggers.Count < 1)
            return;
        for (int i = 0; i < triggers.Count; i++) {
            triggers[i].SetActive(!triggers[i].activeSelf);
        }
    }
}
