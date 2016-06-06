using UnityEngine;
using System.Collections;

public class MenuSounds : MonoBehaviour {
    private string sfxPrefix = "sfx/";

    public AudioSource soundSource, musicSource;
    private AudioClip selectionClip, confirmClip, startChangeClip, endChangeClip;

    void Awake() {
        selectionClip = (AudioClip)Resources.Load(sfxPrefix + "MenuSelect");
        confirmClip = (AudioClip)Resources.Load(sfxPrefix + "MenuConfirm");
        startChangeClip = (AudioClip)Resources.Load(sfxPrefix + "MenuStartScreenChange");
        endChangeClip = (AudioClip)Resources.Load(sfxPrefix + "MenuEndScreenChange");
    }

    void Start() {
        DontDestroyOnLoad(gameObject);
    }

    public void Select() {
        soundSource.PlayOneShot(selectionClip, 0.22f);
    }
    public void Confirm() {
        soundSource.PlayOneShot(confirmClip, 0.22f);
    }
    public void EndChange() {
        soundSource.PlayOneShot(endChangeClip, 0.8f);
    }
    public void StartChange() {
        soundSource.PlayOneShot(startChangeClip, 0.8f);
    }
}
