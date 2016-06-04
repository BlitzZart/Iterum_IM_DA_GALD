using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSceneChanger : MonoBehaviour {

    public static string menuMainName = "MenuMain";
    public static string menuSplashName = "MenuSplash";
    public static string menuPlayName = "iterum_mo_Dani2";
    public static string menuCreditsName = "MenuCredits";
    public static string menuEndName1 = "MenuEnd1";
    public static string menuEndName2 = "MenuEnd2";
    //public static string menuControlsName = "MenuControls";

    public Color fadeColor = new Color(0f, 0f, 0f);

    public GameObject menuPanel;
    private RectTransform panelRect;

    public float transitionDuration = 0.66f;

    private Hashtable outTransition;
    private Hashtable inTransition;

    MenuSounds menuSounds;

    // Use this for initialization
    void Start () {
        menuSounds = FindObjectOfType<MenuSounds>();
        InitTransition();
        InTransition();
	}

    private void InitTransition() {
        panelRect = menuPanel.GetComponent<RectTransform>();
        outTransition = new Hashtable();
        //outTransition.Add("y", 10.1f); //panelRect.rect.size.y * menuPanel.GetComponentInParent<Canvas>().GetComponent<RectTransform>().localScale.y + 1);
        outTransition.Add("time", transitionDuration);
        outTransition.Add("easeType", iTween.EaseType.easeInOutExpo);

        inTransition = new Hashtable();
        //inTransition.Add("y", 0);
        inTransition.Add("time", transitionDuration);
        inTransition.Add("easeType", iTween.EaseType.easeInOutExpo);
    }

    public void OutTransition() {
        //iTween.MoveTo(menuPanel, outTransition);
        iTween.ScaleTo(menuPanel, Vector3.one * 0.13f, transitionDuration * 8);
        iTween.CameraFadeAdd(iTween.CameraTexture(fadeColor));
        iTween.CameraFadeTo(1, transitionDuration);
    }

    public void InTransition () {   
        //panelRect.anchoredPosition = new Vector3(0, 0/*- (panelRect.rect.height)*/, 0);
        panelRect.localScale = Vector2.zero;
        //        iTween.MoveTo(menuPanel, inTransition);
        iTween.ScaleTo(menuPanel, Vector3.one, transitionDuration * 2);

        iTween.CameraFadeAdd(iTween.CameraTexture(fadeColor));
        iTween.CameraFadeFrom(1, transitionDuration);

        StartCoroutine(TransitionDoneSound(.2f));
    }

    private IEnumerator TransitionDoneSound(float delay) {
        yield return new WaitForSeconds(delay);
        if (menuSounds != null)
            menuSounds.EndChange();
    }

    public void ChangeScene(string name, float delay = 0) {
        if (menuSounds != null)
            menuSounds.StartChange();
        StartCoroutine(Load(name, delay));
    }

    IEnumerator Load(string name, float delay) {
        yield return new WaitForSeconds(delay);
        OutTransition();
        yield return new WaitForSeconds(transitionDuration + 0.1f);
        SceneManager.LoadScene(name);
    }
}
