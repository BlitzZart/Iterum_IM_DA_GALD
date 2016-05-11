using UnityEngine;
using System.Collections;

public class BridgeOfFaith : MonoBehaviour {
    private bool isVisible = true;
    private Transform believer;
    private Vector3 initPosition;

    public bool checkLookDirection = false;
    private PlayerSightChecker backCheck;

    // Use this for initialization
    void Start () {
        isVisible = false;
        initPosition = transform.position;
        backCheck = GetComponentInChildren<PlayerSightChecker>();

        // disable player sight check
        if (!checkLookDirection)
        {
            backCheck.gameObject.SetActive(false);
        }
	}

    // Update is called once per frame
    void Update () {

        /// ---- was used for first iteration of bridge
        // check if bridge is visible and beliver is assigned
        //if (isVisible || believer == null)
        //    return;
        //if (checkLookDirection && !backCheck.IsVisible)
        //    return;
        /// ---- 

        if (believer != null)
            transform.position = new Vector3(believer.position.x, initPosition.y, believer.position.z);
    }

    void MsgPlayerEntered(GameObject player)
    {
        believer = player.transform;
    }

    void MsgPlayerLeft()
    {
        //believer = null;
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
