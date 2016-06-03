using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class MenuPostEffects : MonoBehaviour {

    public float bloomRate, bloomSpeed, BloomRange;
    //public float fishEyeRate, fishEyeSpeed, fishEyeRange;

    public bool skyRotation = false;
    public float skyboxRotationSpeed = 1;
    public float skyRate, skySpeed, skyRange;



    Bloom bloom;
    Fisheye fishEye;
    VignetteAndChromaticAberration vigAndCrom;

    FloatManipulator bloomLerper;
    FloatManipulator fishEyeLerper;
    FloatManipulator skyBoxLerper;

    // Use this for initialization
    void Start() {
        bloom = GetComponent<Bloom>();
        fishEye = GetComponent<Fisheye>();
        vigAndCrom = GetComponent<VignetteAndChromaticAberration>();
        bloomLerper = new FloatManipulator(bloom.bloomIntensity, bloomRate, bloomSpeed, BloomRange);
        //fishEyeLerper = new FloatManipulator(fishEye.strengthY, fishEyeRate, fishEyeSpeed, fishEyeRange);
        skyBoxLerper = new FloatManipulator(skyboxRotationSpeed, skyRate, skySpeed, skyRange);
    }

    float rot;
    void RotateSky() {
        rot = skyBoxLerper.GetRadomValues(Time.deltaTime);
        rot %= 360;
        //print(skyBoxLerper.GetRadomValues(Time.deltaTime));
        RenderSettings.skybox.SetFloat("_Rotation", rot);
    }

    // Update is called once per frame
    void Update() {
        bloom.bloomIntensity = bloomLerper.GetRadomValues(Time.deltaTime);
        //float fish = fishEyeLerper.GetRadomValues(Time.deltaTime);
        //fishEye.strengthY = fish;
        //fishEye.strengthX = 0.1f * fish;
        if (skyRotation)
            RotateSky();
    }
}
