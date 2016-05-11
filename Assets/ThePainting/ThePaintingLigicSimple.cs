using UnityEngine;
using System.Collections;

public class ThePaintingLigicSimple : MonoBehaviour {
    private GameObject painting;

    private bool activated = false;

    // Use this for initialization
    void Start() {
        painting = GetComponentInChildren<MeshRenderer>().gameObject;
        painting.SetActive(false);
    }

    void MsgPlayerEntered(GameObject player) {
        if (activated)
            return;

        activated = true;

        painting.SetActive(true);
    }
}
