using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class FinalEffect : MonoBehaviour {
    Bloom bloom;
    bool fadeToWhite = false;

    float timeBeforeLock = 3.0f;
    float timeBeforeFade = 7.5f;
    float bloomFadeDuration = 11.7f;
    float endScreenFadeDuration = 2.77f;

    Color endScreenFadeColor = new Color(1, 1, 1, 1);

    float currentTime = 0;

    float intensity_a;
    float threshold_a;

    float intensity_b = 25;
    float threshold_b = 0;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            FirstPersonController fpsC = other.GetComponent<FirstPersonController>();
            StartCoroutine(GameOverSequence(fpsC));
        }
    }

    IEnumerator GameOverSequence(FirstPersonController fpsC) {
        // slow down
        if (fpsC != null) { 
            fpsC.SlowSpeed(0.5f);
            fpsC.GetComponent<AudioSource>().volume = 0;
        }
        // lock player
        yield return new WaitForSeconds(timeBeforeLock);
        if (fpsC != null) { 
            FinalLookUp lu = FindObjectOfType<FinalLookUp>();
            lu.StartMoving(fpsC, bloomFadeDuration);
        }
        // start bloom fade
        yield return new WaitForSeconds(timeBeforeFade);
        bloom = Camera.main.GetComponent<Bloom>(); 
        if (bloom != null) {
            bloom.enabled = true;

            intensity_a = bloom.bloomIntensity;
            threshold_a = bloom.bloomThreshold;
            fadeToWhite = true;
        }

        // start cam fade to white
        yield return new WaitForSeconds(bloomFadeDuration); 
        iTween.CameraFadeAdd(iTween.CameraTexture(endScreenFadeColor));
        iTween.CameraFadeFrom(1, endScreenFadeDuration);

        // load end screen
        yield return new WaitForSeconds(endScreenFadeDuration);
        FreeHeart();
        SceneManager.LoadScene(MenuSceneChanger.menuEndName1);
    }

    private void FreeHeart() {
        HeartBeat heart = FindObjectOfType<HeartBeat>();
        if (heart != null) {
            heart.enabled = false;
            heart.GetComponent<HeartDeformer>().enabled = false;
            heart.transform.parent = null;
            heart.transform.position = Vector3.zero;
            DontDestroyOnLoad(heart.gameObject);
        }
    }

    private void FadeTo() {
        if (fadeToWhite) {
            bloom.bloomIntensity = Mathf.Lerp(intensity_a, intensity_b, currentTime);
            bloom.bloomThreshold = Mathf.Lerp(threshold_a, threshold_b, currentTime);

            currentTime += Time.deltaTime / bloomFadeDuration;

            if (currentTime > bloomFadeDuration * 2)
                Time.timeScale = 0;
        }
    }

    // Update is called once per frame
    void Update () {
        FadeTo();
	}
}