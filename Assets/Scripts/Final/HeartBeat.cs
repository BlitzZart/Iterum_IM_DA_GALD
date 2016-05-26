using UnityEngine;
using System.Collections;

public class HeartBeat : MonoBehaviour {

    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = 0.23f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
