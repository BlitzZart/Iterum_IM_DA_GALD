using UnityEngine;
using System.Collections;

public class MenuMainButtons : MonoBehaviour {
    public void LoadLobby() {
        GetComponent<MenuSceneChanger>().ChangeScene(MenuSceneChanger.menuPlayName);
    }
    //public void LoadControls() {
    //    GetComponent<MenuSceneChanger>().ChangeScene(MenuSceneChanger.menuControlsName);
    //}
    public void LoadMain() {
        GetComponent<MenuSceneChanger>().ChangeScene(MenuSceneChanger.menuMainName);
    }
    public void LoadCredits() {
        GetComponent<MenuSceneChanger>().ChangeScene(MenuSceneChanger.menuCreditsName);
    }
    public void QuitGame() {
        GetComponent<MenuSceneChanger>().ChangeScene(MenuSceneChanger.menuSplashName);
    }
}
