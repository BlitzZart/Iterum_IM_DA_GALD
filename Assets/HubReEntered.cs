using UnityEngine;
using System.Collections;

public class HubReEntered : MonoBehaviour {

	void OnEnable () {
        GetComponentInParent<EventSounds>().PlayHubSound();
	}
}
