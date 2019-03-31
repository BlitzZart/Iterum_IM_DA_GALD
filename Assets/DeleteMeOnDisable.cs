using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMeOnDisable : MonoBehaviour {
    private void OnDisable()
    {
        // deleting areas can lead to problems
        // if not deactivated properly before star
        Debug.Log("DELETED " + gameObject.name);
        Destroy(gameObject);
    }
}
