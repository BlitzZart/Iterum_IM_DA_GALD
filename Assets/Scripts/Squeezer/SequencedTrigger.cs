using UnityEngine;
using System.Collections;

namespace Triggers {
    public class SequencedTrigger : MonoBehaviour {
        public TriggerType triggerType;

        private bool playerInside = false;

        public bool PlayerInside {
            get {
                return playerInside;
            }
        }

        void OnTriggerEnter(Collider collider) {
            playerInside = true;
            SendMessageUpwards("Triggered", triggerType);
        }
        void OnTriggerExit(Collider collider) {
            playerInside = false;
        }
    }
}