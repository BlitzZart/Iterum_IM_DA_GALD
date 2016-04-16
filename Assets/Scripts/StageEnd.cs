using UnityEngine;
using System.Collections;

public class StageEnd : MonoBehaviour {
    public delegate void Stage(int stageNumber);
    public static event Stage EndOfStage;

    public int stageNumber = 0;
    
    public void FireEndEvent() {
        if (EndOfStage != null)
            EndOfStage(stageNumber);
    }
     
}
