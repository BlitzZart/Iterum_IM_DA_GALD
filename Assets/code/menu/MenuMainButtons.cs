using UnityEngine;
using System.Collections;

public class MenuMainButtons : MonoBehaviour {
    public void LoadPlayState() {
        MenuSounds ms = FindObjectOfType<MenuSounds>();
        if (ms != null)
            Destroy(ms.gameObject);
        GetComponent<MenuSceneChanger>().ChangeScene(MenuSceneChanger.menuPlayName);
    }
    //public void LoadControls() {
    //    GetComponent<MenuSceneChanger>().ChangeScene(MenuSceneChanger.menuControlsName);
    //}
    public void LoadMain() {
        GetComponent<MenuSceneChanger>().ChangeScene(MenuSceneChanger.menuMainName);
    }
    public void LoadControls()
    {
        GetComponent<MenuSceneChanger>().ChangeScene(MenuSceneChanger.menuControlsName);
    }
    public void LoadCredits() {
        GetComponent<MenuSceneChanger>().ChangeScene(MenuSceneChanger.menuCreditsName);
    }
    public void LoadEndGame() {
        GetComponent<MenuSceneChanger>().ChangeScene(MenuSceneChanger.menuEndName1);
    }
    public void QuitGame() {
        GetComponent<MenuSceneChanger>().ChangeScene(MenuSceneChanger.menuSplashName);
    }
}
