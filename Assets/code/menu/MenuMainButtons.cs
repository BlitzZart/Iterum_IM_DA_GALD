using UnityEngine;
using System.Collections;

public class MenuMainButtons : MonoBehaviour {

    [SerializeField] private GameObject m_loadingPanel;

    public void LoadPlayState() {
        MenuSounds ms = FindObjectOfType<MenuSounds>();
        if (ms != null)
            Destroy(ms.gameObject);
        GetComponent<MenuSceneChanger>().ChangeScene(MenuSceneChanger.menuPlayName);

        m_loadingPanel?.SetActive(true);
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
    public void LoadEndGame() {
        GetComponent<MenuSceneChanger>().ChangeScene(MenuSceneChanger.menuEndName1);
    }
    public void QuitGame() {
        GetComponent<MenuSceneChanger>().ChangeScene(MenuSceneChanger.menuSplashName);
    }
}
