using UnityEngine;
using System.Collections;

/// <summary>
/// used as parent for the player transform - when not assigned to other rooms
/// </summary>
public class PlayerHome : MonoBehaviour {
    private static PlayerHome instance;
    public static PlayerHome Instance { get { return instance; } }


	// Use this for initialization
	void Awake () {
        instance = this;
	}

}
