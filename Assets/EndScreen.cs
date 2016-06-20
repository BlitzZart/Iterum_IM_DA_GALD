using UnityEngine;
using System.Collections;

public class EndScreen : MonoBehaviour {
    private float showDuration = 7.333f;

    private static int endScreenPage = 0;

    // Use this for initialization
    void Start() {

        endScreenPage++;
        if (endScreenPage == 1) {
            ShowHeart(false);
            GetComponent<MenuSceneChanger>().ChangeScene(MenuSceneChanger.menuEndName2, showDuration);
        }
        else if (endScreenPage == 2) {
            ShowHeart(true);
            GetComponent<MenuSceneChanger>().ChangeScene(MenuSceneChanger.menuMainName, showDuration);
        }
    }

    private void ShowHeart(bool show) {
        HeartBeat heart = FindObjectOfType<HeartBeat>();

        if (heart == null)
            return;

        heart.GetComponent<MeshDeformer>().enabled = true;
        heart.GetComponent<FFT>().enabled = true;

        heart.GetComponent<MeshRenderer>().enabled = show;

        heart.transform.position = new Vector3(1.35f, -9.48f, -65.97f);
        heart.transform.rotation = Quaternion.Euler(0.0f, 267.9f, 0.44f);
        heart.transform.localScale = Vector3.one * 1.73f;
    }

    // Update is called once per frame
    void Update() {
        if (Input.anyKeyDown) {
            if (endScreenPage == 1) {
                GetComponent<MenuSceneChanger>().ChangeScene(MenuSceneChanger.menuEndName2, 0);
            }
            else if (endScreenPage == 2) {
                GetComponent<MenuSceneChanger>().ChangeScene(MenuSceneChanger.menuMainName, 0);
            }
        }
    }
}