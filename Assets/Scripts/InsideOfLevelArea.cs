using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideOfLevelArea : MonoBehaviour
{
    public bool playerIsInside = false;
    private void OnTriggerEnter(Collider other)
    {
        playerIsInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerIsInside = false;
    }
}
