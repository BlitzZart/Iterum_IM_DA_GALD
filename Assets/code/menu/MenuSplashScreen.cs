using UnityEngine;
using System.Collections;
using System;

// first screen of the application
// also shown before quit
public class MenuSplashScreen : MonoBehaviour {

    public float splashScreenDuration = 3.0f;

    private static bool loadedOnce = false;

    // Use this for initialization
    void Start() {
        // only go to main menu when game starts
        if (!loadedOnce) {
            //Cursor.visible = false;
            GetComponent<MenuSceneChanger>().ChangeScene(MenuSceneChanger.menuMainName, splashScreenDuration);
            loadedOnce = true;
        }
        else {
            StartCoroutine(QuitApplicationDelayed());
        }
    }

    private IEnumerator QuitApplicationDelayed() {
        yield return new WaitForSeconds(splashScreenDuration);
        Application.Quit();
    }
}
