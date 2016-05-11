using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class TeleportManipulatePlayer : MonoBehaviour {

    void TeleporterEntered(GameObject player)
    {
        FirstPersonController fpsC = player.GetComponent<FirstPersonController>();

        if (fpsC != null)
        {
            fpsC.SetMoveDir(Vector3.zero);
        }
    }
}
