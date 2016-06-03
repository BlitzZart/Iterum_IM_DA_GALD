using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
    public MenuSounds menuMusicPrefab;
    // Use this for initialization
    void Start () {
        // instantiate menu music
        if (FindObjectOfType<MenuSounds>() == null)
            Instantiate(menuMusicPrefab);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
