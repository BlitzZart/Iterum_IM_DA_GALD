using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {

    private bool doComeIn = false;

    private Hashtable ht = new Hashtable();

    public Transform tt;

    public void ComeIn() {

        iTween.MoveTo(gameObject, ht);
    }

	// Use this for initialization
	void Start () {
        ht.Add("x", tt.position.x);
        ht.Add("y", tt.position.y);
        ht.Add("z", tt.position.z);
        ht.Add("time", 60);
        ht.Add("easeType", iTween.EaseType.easeOutElastic);

        ComeIn();
    }
	


	// Update is called once per frame
	void Update () {
	
	}
}
