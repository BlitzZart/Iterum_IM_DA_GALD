using UnityEngine;
using UnityEngine.UI;

public class IngameMenu : MonoBehaviour {

    GameObject ui;
    MenuMainButtons menuButtons;

    // Use this for initialization
    void Start() {
        ui = GetComponentInChildren<Image>().gameObject;
        menuButtons = GetComponent<MenuMainButtons>();

        ui.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ui.SetActive(!ui.activeSelf);
            if (ui.activeSelf)
                GetComponent<MenuSceneChanger>().InTransition();
        }
        if (ui.activeSelf) {
            if (Input.GetKeyDown(KeyCode.Return))
                menuButtons.LoadMain();
        }
    }
}