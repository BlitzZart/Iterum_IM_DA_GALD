﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StageInGameDebug : MonoBehaviour {

    private Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();

        GameManager.StageChange += ShowStage;
	}
	
    void ShowStage(int stage) {
        text.text = "Stage: " + stage;
    }


	// Update is called once per frame
	void Update () {
	
	}
}
