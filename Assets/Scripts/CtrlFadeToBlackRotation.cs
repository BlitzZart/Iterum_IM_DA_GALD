using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CtrlFadeToBlackRotation : MonoBehaviour {

    public static string USE_CLASSIC_ROTATION = "ClassicRotation";

    private Toggle m_toggle;

    private void Start()
    {
        m_toggle = GetComponent<Toggle>();

        int classicRotation = PlayerPrefs.GetInt(USE_CLASSIC_ROTATION);

        print(classicRotation + " fadde");


        if (classicRotation > 0)
        {
            m_toggle.isOn = true;
        }
        else
        {
            m_toggle.isOn = false;
        }
    }

    public void ToggleChanged()
    {
        int intVal = 0;
        if (m_toggle.isOn) { intVal = 1; }

        PlayerPrefs.SetInt(USE_CLASSIC_ROTATION, intVal);
    }
}
