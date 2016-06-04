using UnityEngine;
using System.Collections;

public class HeartAttack : MonoBehaviour {

    // destroys hearts - happens after leaving play state
	void Start () {
        HeartBeat heart = FindObjectOfType<HeartBeat>();

        if (heart != null)
            Destroy(heart.gameObject);
	}
}
