using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectDefaultButton : MonoBehaviour {
	void Start () {
        GetComponentInChildren<Button>().Select();
	}
}
