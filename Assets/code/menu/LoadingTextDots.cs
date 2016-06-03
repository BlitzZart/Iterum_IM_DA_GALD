using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingTextDots : MonoBehaviour {

    Text text;

    float rate = .33f;
    int dots = 3;

    void Start() {
        text = GetComponent<Text>();
    }

    float currTime = 0;
    int currDots = 0;
    void Update() {
        if (currTime < rate) {
            currTime += Time.deltaTime;
        }
        else {
            currDots++;
            if (dots >= currDots) {
                text.text += ".";
            }
            else {
                currDots = 0;
                text.text = "";
            }

            currTime = 0;
        }
    }
}
