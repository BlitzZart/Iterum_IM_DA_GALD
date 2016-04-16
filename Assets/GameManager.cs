using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour {

    public int currentStage = 0;

    public List<GameObject> enableOnStart;
    public List<GameObject> disableOnStart;

    public List<GameObject> stage1DoneOn;
    public List<GameObject> stage1DoneOff;
    public List<GameObject> stage2DoneOn;
    public List<GameObject> stage2DoneOff;
    public List<GameObject> stage3DoneOn;
    public List<GameObject> stage3DoneOff;

    private List<List<GameObject>> allOn;
    private List<List<GameObject>> allOff;

    // Use this for initialization
    void Start() {
        allOn = new List<List<GameObject>>();
        allOff = new List<List<GameObject>>();

        allOn.Add(stage1DoneOn);
        allOn.Add(stage2DoneOn);
        allOn.Add(stage3DoneOn);

        allOff.Add(stage1DoneOff);
        allOff.Add(stage2DoneOff);
        allOff.Add(stage3DoneOff);

        StartFirstStage();

        StageEnd.EndOfStage += StageFinished;
    }

    private void StartFirstStage() {
        currentStage = 0;
    }

    public void StageFinished(int stageNumber) {
        DisableAndEnable(stageNumber);
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