using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.ImageEffects;

public class CHEATS : MonoBehaviour {

    private bool cheat_run = false;
    private float cheat_runSpeed = 29;
    private float original_runSpeed = 9;

	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0)) {
            if (Input.GetKey(KeyCode.X)) {
                if (Input.GetKey(KeyCode.C)) {
                    FirstPersonController fpsc = GetComponent<FirstPersonController>();
                    if (fpsc == null)
                        return;

                    cheat_run = !cheat_run;

                    if (cheat_run) {
                        original_runSpeed = fpsc.m_RunSpeed;
                        fpsc.m_RunSpeed = cheat_runSpeed;
                    }
                    else {
                        fpsc.m_RunSpeed = original_runSpeed;
                    }
                }
                else if (Input.GetKey(KeyCode.V)) {
                    EdgeDetection ed = GetComponentInChildren<EdgeDetection>();
                    if (ed == null)
                        return;

                    ed.enabled = !ed.enabled;
                }
            }
        }
	}
}