using UnityEngine;
using System.Collections;
using Triggers;

public class EventSounds : MonoBehaviour {
    public float magicVolume = 1;
    public float fallVolume = 1;


    private string sfxPrefix = "sfx/";
    private AudioClip eventClip, fallClip;
    private AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();

        SequencedTriggerManager.magicTriggered += PlayMagicSound;
        StartFallingSound.fallingStartTriggered += PlayFallingSound;
        EndFallingSound.fallingStopTriggered += StopFallingSound;

        eventClip = (AudioClip)Resources.Load(sfxPrefix + "EventSound1");
        fallClip = (AudioClip)Resources.Load(sfxPrefix + "FallSound1");
    }

    public void PlayMagicSound() {
        source.clip = eventClip;
        source.volume = magicVolume;
        source.Play();
    }

    public void PlayFallingSound() {
        source.clip = fallClip;
        source.volume = fallVolume;
        source.Play();
    }

    public void StopFallingSound() {
        print("STOP");
        source.Stop();
    }

    void Dispose() {
        SequencedTriggerManager.magicTriggered -= PlayMagicSound;
        StartFallingSound.fallingStartTriggered -= PlayFallingSound;
        EndFallingSound.fallingStopTriggered -= StopFallingSound;
    }
}
