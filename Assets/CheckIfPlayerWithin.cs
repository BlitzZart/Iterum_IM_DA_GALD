using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfPlayerWithin : MonoBehaviour {
    [SerializeField]
    private bool playerIsWithin = false;
    public bool PlayerIsWithin {
        get {
            return playerIsWithin;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerIsWithin = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerIsWithin = false;
    }

}
