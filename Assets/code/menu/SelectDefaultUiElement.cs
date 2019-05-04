using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectDefaultUiElement : MonoBehaviour {
    void Start()
    {
        GetComponentInChildren<Selectable>().Select();
    }
}
