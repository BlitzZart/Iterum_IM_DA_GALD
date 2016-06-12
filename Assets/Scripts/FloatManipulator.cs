using UnityEngine;
using System.Collections;

public class FloatManipulator {
    private float originalValue;
    private float originalRate;
    private float speed;
    private float range;
    private float randomRange;

    private float cTime; // current time
    private float cValue; //current value(return)
    private float cRandValue; // current ramdom Value
    private float cRate; // current randomized rate

    public FloatManipulator(float originalValue, float rate, float speed, float randomRange) {
        this.originalValue = originalValue;
        this.cValue = originalValue;
        this.originalRate = cRate = (rate != 0.0f) ? rate : 1;
        this.speed = speed;
        this.randomRange = (randomRange > 0) ? randomRange : 1;
    }

    public float GetRadomValues(float dt) {
        if (cTime < cRate) {
            cTime += dt;
            cValue = Mathf.Lerp(cValue, originalValue + cRandValue, dt * speed );
        } else {
            cTime = 0;
            if (randomRange > 0) {
                cRandValue = Random.Range(-randomRange, randomRange);
                cRate = originalRate * Mathf.Abs(cRandValue);
            }
        }
        return cValue;
    }
}
