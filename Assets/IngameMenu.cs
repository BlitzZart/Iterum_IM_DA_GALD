using UnityEngine;
using UnityEngine.UI;

public class IngameMenu : MonoBehaviour {

    GameObject ui;
    MenuMainButtons menuButtons;
    FadeInOut fader;

    // Use this for initialization
    void Start() {
        ui = GetComponentInChildren<Image>().gameObject;
        menuButtons = GetComponent<MenuMainButtons>();
        fader = GetComponent<FadeInOut>();

        ui.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("InGameMenu")/*Input.GetKeyDown(KeyCode.Escape)*/) {
            ui.SetActive(!ui.activeSelf);
            if (ui.activeSelf)
                GetComponent<MenuSceneChanger>().InTransition();
        }
        if (ui.activeSelf) {
            if (Input.GetButtonDown("Cancel")/*Input.GetKeyDown(KeyCode.Return)*/) {
                menuButtons.LoadMain();
            }
        }
    }

    public void ShowMenu()
    {
        ui.SetActive(!ui.activeSelf);
        if (ui.activeSelf)
            GetComponent<MenuSceneChanger>().InTransition();
    }

    public void Continue()
    {
        ui.SetActive(false);
    }

    public void Quit()
    {
        if (ui.activeSelf)
        {
            menuButtons.LoadMain();
        }
    }
}