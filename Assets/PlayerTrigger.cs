using UnityEngine;
using System.Collections;

public class PlayerTrigger : MonoBehaviour {

    void PlayerEntered(GameObject other)
    {
        SendMessageUpwards("MsgPlayerEntered", other);
    }

    void PlayerLeft()
    {
        SendMessageUpwards("MsgPlayerLeft");
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
