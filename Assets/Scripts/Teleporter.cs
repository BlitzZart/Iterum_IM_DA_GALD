using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour,ISwitchable {

    public GameObject start, goal;

    void TeleporterEntered(GameObject player) {
        player.gameObject.transform.position = goal.transform.position;

        StageEnd end = GetComponent<StageEnd>();
        if (end != null)
            end.FireEndEvent();
    }

    public void Activate() {
        enabled = true;
    }

    public void DeActivate() {
        start.SetActive(false);
    }

    public bool GetState() {
        return enabled;
    }

    public void Switch() {
        enabled = !enabled;
    }
}
