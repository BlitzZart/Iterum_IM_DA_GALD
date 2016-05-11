using UnityEngine;
using System.Collections;

public class PlayerTrigger : MonoBehaviour {

    public bool sendStageEndMessage = false;

    void PlayerEntered(GameObject other)
    {
        SendMessageUpwards("MsgPlayerEntered", other, SendMessageOptions.DontRequireReceiver);
        if (sendStageEndMessage) {
            SendMessageUpwards("MsgStageEnd", other, SendMessageOptions.DontRequireReceiver);
        }
    }

    void PlayerLeft()
    {
        SendMessageUpwards("MsgPlayerLeft", SendMessageOptions.DontRequireReceiver);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerEntered(other.gameObject);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerLeft();
        }
    }
}
