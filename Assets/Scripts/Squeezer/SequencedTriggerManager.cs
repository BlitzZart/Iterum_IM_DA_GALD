using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Triggers {
    public enum TriggerType {
        None = 0, A = 1, B = 2
    }
    public class SequencedTriggerManager : MonoBehaviour {
        private TriggerType lastTrigger;
        public SequencedTrigger triggerA, triggerB;

        // event fired by sequenced triggers
        void Triggered(TriggerType entered) {
            // entered the same againw
            if (entered == lastTrigger)
                return;

            // entered the first trigger, store current trigger and return
            if (lastTrigger == TriggerType.None) {
                lastTrigger = entered;
                return;
            }

            // either changed from A to B or B to A (allways is in both)
            if (triggerA.PlayerInside && entered == TriggerType.B ||
                triggerB.PlayerInside && entered == TriggerType.A) {
                SendMessageUpwards("TriggerChanged", entered);
            }
            lastTrigger = entered;
        }
    }
}