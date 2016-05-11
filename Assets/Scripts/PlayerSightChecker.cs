using UnityEngine;
using System.Collections;

public class PlayerSightChecker : MonoBehaviour {
    private bool isVisible;
    public bool IsVisible
    {
        get { return isVisible; }
    }

    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);

    }
    void OnWillRenderObject()
    {
        isVisible = true;
    }
    void OnBecameInvisible()
    {
        isVisible = false;
    }
    void OnBecameVisible()
    {
        isVisible = true;
    }
}
