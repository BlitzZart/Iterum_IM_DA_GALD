using UnityEngine;
using System.Collections;

public class PlayerHome : MonoBehaviour {
    private static PlayerHome instance;
    public static PlayerHome Instance { get { return instance; } }


	// Use this for initialization
	void Awake () {
        instance = this;
	}

}
