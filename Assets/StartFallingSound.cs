using UnityEngine;

namespace Triggers {
    public class StartFallingSound : MonoBehaviour {
        public static TriggerDelegate fallingStartTriggered;

        void MsgPlayerEntered(GameObject player) {
            if (fallingStartTriggered != null)
                fallingStartTriggered();
        }
    }
}