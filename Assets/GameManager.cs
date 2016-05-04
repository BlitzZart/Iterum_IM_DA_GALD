﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour {
    private static GameManager instance;
    public static GameManager Instance {
        get { return instance; }
    }

    public delegate void Game(int stageNumber);
    public static event Game StageChange;


    public int currentStage = 0;

    public List<GameObject> enableOnStart;
    public List<GameObject> disableOnStart;

    public List<GameObject> stage1DoneOn;
    public List<GameObject> stage1DoneOff;
    public List<GameObject> stage2DoneOn;
    public List<GameObject> stage2DoneOff;
    public List<GameObject> stage3DoneOn;
    public List<GameObject> stage3DoneOff;
    public List<GameObject> stage4DoneOn;
    public List<GameObject> stage4DoneOff;

    private List<List<GameObject>> allOn;
    private List<List<GameObject>> allOff;

    void Awake() {
        instance = this;
    }

    void Start() {
        allOn = new List<List<GameObject>>();
        allOff = new List<List<GameObject>>();

        allOn.Add(stage1DoneOn);
        allOn.Add(stage2DoneOn);
        allOn.Add(stage3DoneOn);
        allOn.Add(stage4DoneOn);

        allOff.Add(stage1DoneOff);
        allOff.Add(stage2DoneOff);
        allOff.Add(stage3DoneOff);
        allOff.Add(stage4DoneOff);

        StartFirstStage();

        StageEnd.EndOfStage += StageFinished;
    }

    private void StartFirstStage() {
        currentStage = 0;
    }

    public void StageFinished(int stageNumber) {
        DisableAndEnable(stageNumber);

        if (StageChange != null) {
            StageChange(stageNumber);
        }
    }

    // if go is ISWITCH, use it. Ohtwerwise - gameObject.enabled = false;
    private void DisableAndEnable(int stage) {
        if (stage <= 0) {
            Debug.Log("Invalid stage number " + stage + ".");
            return;
        }
        foreach (GameObject go in allOff[stage - 1]) {
            ISwitchable iSwitch = go.GetComponent<ISwitchable>();
            if (iSwitch != null)
                iSwitch.DeActivate();
            else
                go.SetActive(false);
        }

        foreach (GameObject go in allOn[stage - 1]) {
            ISwitchable iSwitch = go.GetComponent<ISwitchable>();
            if (iSwitch != null)
                iSwitch.Activate();
            else
                go.SetActive(true);
        }
    }
}