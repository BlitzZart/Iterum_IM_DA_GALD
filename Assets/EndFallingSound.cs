using UnityEngine;

namespace Triggers {
    public class EndFallingSound : MonoBehaviour {
        public static TriggerDelegate fallingStopTriggered;

        void MsgPlayerEntered(GameObject player) {
            if (fallingStopTriggered != null)
                fallingStopTriggered();
        }
    }
}