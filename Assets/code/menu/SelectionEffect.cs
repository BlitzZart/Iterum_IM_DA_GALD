using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class SelectionEffect : MonoBehaviour, ISelectHandler, IDeselectHandler, ISubmitHandler {
 
    private Button button;
    private Text text;
    private Color baseColor;
    private MenuSounds menuSounds;
    public Color highlightedColor = Color.white;

    private float time = 0.15f;
    private float scaleFactor = 0.95f;

    private Hashtable selTween, deselTween;

    void Awake() {
        InitEffects();
    }

    void Start() {
        menuSounds = FindObjectOfType<MenuSounds>();
    }

    private void InitEffects() {
        selTween = new Hashtable();
        selTween.Add("x", 1);
        selTween.Add("y", 1);
        selTween.Add("time", time);
        //selTween.Add("easeType", iTween.EaseType.easeInOutQuad);
        selTween.Add("loopType", iTween.LoopType.pingPong);
        selTween.Add("speed", 0.11f);

        deselTween = new Hashtable();
        deselTween.Add("x", scaleFactor);
        deselTween.Add("y", scaleFactor);
        deselTween.Add("time", time);
        deselTween.Add("easeType", iTween.EaseType.easeInOutExpo);

        button = GetComponent<Button>();
        text = GetComponentInChildren<Text>();
        baseColor = text.color;
        gameObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
    }

    public void OnSelect(BaseEventData eventData) {
        iTween.ScaleTo(this.gameObject, selTween);
        text.color = highlightedColor;

        if (menuSounds == null)
            menuSounds = FindObjectOfType<MenuSounds>();
        else
            menuSounds.Select();
    }

    public void OnDeselect(BaseEventData eventData) {
        iTween.ScaleTo(this.gameObject, deselTween);
        text.color = baseColor;
    }

    public void OnSubmit(BaseEventData eventData) {
        if (menuSounds == null)
            menuSounds = FindObjectOfType<MenuSounds>();
        else
            menuSounds.Confirm();
    }
}