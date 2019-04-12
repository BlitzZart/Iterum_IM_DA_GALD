using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class VrFpsControl : MonoBehaviour
{

    public FadeMaterials toBlack;

    private bool m_readyToRotate = true;
    private float m_deadZone = 0.1f;

    private float m_turnStep = 45.0f;

    private FirstPersonController m_fpsCtrl;

    // Use this for initialization
    void Start()
    {
        m_fpsCtrl = GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        float turn = Input.GetAxis("RightStickX_Win");
#elif UNITY_STANDALONE_OSX
        float turn = Input.GetAxis("RightStickX_Mac");
#endif

        // keyboard input

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            turn = 1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            turn = -1;
        }


        if (Mathf.Abs(turn) < m_deadZone)
        {
            m_readyToRotate = true;

        }

        if (m_readyToRotate && Mathf.Abs(turn) > m_deadZone)
        {

            m_readyToRotate = false;

            if (turn > 0)
            {
                toBlack.ShortBlack();
                StopAllCoroutines();
                StartCoroutine(Turn(m_turnStep));
            }
            else
            {
                toBlack.ShortBlack();
                StopAllCoroutines();
                StartCoroutine(Turn(-m_turnStep));
            }
        }


    }
    private IEnumerator Turn(float dir)
    {
        toBlack.FadeOut(0.05f);
        yield return new WaitForSeconds(0.05f);
        m_fpsCtrl.RotateBy(dir);
        toBlack.FadeIn(0.15f);
    }

}
