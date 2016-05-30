using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnteredPuzzle : MonoBehaviour {

    [Header("Player Parentign. False sets parent to PlayerHome")]
    public bool parentPlayerToGameObject = true;
    private GameObject player;

    [Header("Transformation")]
    public Vector3 targetPosition;
    public float targetRotation = 9999;

    // the entrance door which blocks the way back
    [Header("CheckPlayerSight")]
    private bool doOnlyIfNotVisible = true; // if false - it happens immediately
    public GameObject sightCheck;
    private Renderer sightCheckRenderer;

    // furthe object to activate/deactivate
    [Header("GameObject Activasion")]
    public List<GameObject> toDeactivate;
    public List<GameObject> toActivate;

    void Start() {
        if (sightCheck == null)
            doOnlyIfNotVisible = false;
    }

    void MsgPlayerEntered(GameObject player) {
        this.player = player;
        if (doOnlyIfNotVisible) {
            sightCheckRenderer = sightCheck.GetComponent<Renderer>();
            InvokeRepeating("TryToApply", 0.1f, 0.1f);
        } else {
            ApplyChanges();
        }
    }

    void TryToApply() {
        if (!sightCheckRenderer.isVisible) {
            CancelInvoke("TryToApply");
            ApplyChanges();
        }
    }

    void ParentFPSC() {
        if (parentPlayerToGameObject) {
            player.transform.parent = transform.parent;
        }
        else {
            // set rotation of player home to rotation of current room
            PlayerHome.Instance.transform.rotation = transform.parent.rotation;
            player.transform.parent = PlayerHome.Instance.transform;
        }

        player.transform.localScale = new Vector3(1, 1, 1);
    }

    void ApplyChanges() {
        ParentFPSC();

        foreach (GameObject item in toDeactivate)
            item.SetActive(false);
        foreach (GameObject item in toActivate)
            item.SetActive(true);

        if (targetPosition != Vector3.zero)
            transform.parent.position = targetPosition;
        if (targetRotation != 9999)
            transform.parent.rotation = Quaternion.Euler(0, targetRotation, 0);
    }
}
