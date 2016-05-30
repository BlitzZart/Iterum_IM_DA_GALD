using UnityEngine;
using System.Collections;
using System;

public class BeatBox : MonoBehaviour {

    public float volume = 0.6f;
    public AudioClip ambExplore, ambDrama;
    public AudioClip fx01;

    private AudioClip nextClip;
    private AudioSource source;

    private float fadeDuration = 3.33f;
    private float currentTime = 0.0001f;

    private bool doFade = false;
    private bool doFadeOut = false;
    private bool doFadeIn = false;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        GameManager.StageChange += StageChange;
	}

    private void StageChange(int stageNumber) {

        if (stageNumber == 1 && source.clip != ambExplore)
            StartFadeIn(ambExplore, 1.3f);

        if (stageNumber == 4 && source.clip != ambDrama)
            StartFadeOutAndIn(ambDrama, 1.3f);

        if (stageNumber == 5)
            AudioSource.PlayClipAtPoint(fx01, transform.position, 0.6f);

        //if (stageNumber == 6)
        //    AudioSource.PlayClipAtPoint(fx01, transform.position, 0.6f);

    }

    // Update is called once per frame
    void Update() {
        CrossFade();
    }

    public void StartFadeOutAndIn(AudioClip clip, float durateion) {
        fadeDuration = durateion;
        currentTime = fadeDuration;
        doFade = true;
        doFadeOut = true;
        doFadeIn = true;
        nextClip = clip;
    }

    public void StartFadeIn(AudioClip clip, float durateion) {
        fadeDuration = durateion;
        currentTime = 0;
        doFade = true;
        doFadeIn = true;

        source.volume = 0;
        source.clip = clip;
        source.Play();
    }

    public void StartFadeOut(float durateion) {
        fadeDuration = durateion;
        doFade = true;
        doFadeOut = true;
        nextClip = null;
    }

    private void CrossFade() {
        if (doFade) {
            if (doFadeOut) {
                FadeOut();
            }
            else if (doFadeIn) {
                FadeIn();
            }
            source.volume = currentTime / fadeDuration * volume;
        }
    }

    private void FadeOut() {
        if (currentTime < 0) {
            doFadeOut = false;
            source.clip = nextClip; // change audio clip
            source.Play();
        }
        else {
            currentTime -= Time.deltaTime;
        }
    }

    private void FadeIn() {
        if (currentTime > fadeDuration) {
            doFade = false;
            doFadeIn = false;
        }
        else {
            currentTime += Time.deltaTime;
        }
    }

    void Dispose() {
        GameManager.StageChange -= StageChange;
    }
}
