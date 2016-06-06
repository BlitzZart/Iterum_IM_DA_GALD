using UnityEngine;
using System.Collections;
using Triggers;
using System;
using System.Collections.Generic;

public class EventSounds : MonoBehaviour {
    public float magicVolume = 1;
    public float hubEnterVolume = 1;
    public float fallVolume = 1;

    private List<int> enteredHupStages = new List<int>{1,2,3,4,7};

    private string sfxPrefix = "sfx/";
    private AudioClip eventClip, fallClip, hubEnterClip;
    private AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();

        SequencedTriggerManager.magicTriggered += PlayMagicSound;
        StartFallingSound.fallingStartTriggered += PlayFallingSound;
        EndFallingSound.fallingStopTriggered += StopFallingSound;
        StageEnd.EndOfStage += StageFinished;

        eventClip = (AudioClip)Resources.Load(sfxPrefix + "EventSound1");
        fallClip = (AudioClip)Resources.Load(sfxPrefix + "FallSound1");
        hubEnterClip = (AudioClip)Resources.Load(sfxPrefix + "HubEnterSound");
    }

    private void StageFinished(int stageNumber) {
        if (enteredHupStages.Contains(stageNumber)) {
            PlayHubSound();
        }
    }

    public void PlayHubSound() {
        source.clip = hubEnterClip;
        source.volume = hubEnterVolume;
        source.Play();
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
        StageEnd.EndOfStage -= StageFinished;
    }
}
