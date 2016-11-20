using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class GameConfig : MonoBehaviour {



    // Use this for initialization
    void Start() {
        int lvl = QualitySettings.GetQualityLevel();


        Bloom[] blooms = Camera.main.GetComponents<Bloom>();

        // low
        if (lvl == 0) {
            foreach (Bloom item in blooms)
                item.enabled = false;

            ScreenSpaceAmbientOcclusion occlusion = Camera.main.GetComponent<ScreenSpaceAmbientOcclusion>();
            if (occlusion != null)
                occlusion.enabled = false;
        }
        // medium or lower
        if (lvl <= 1) {
            Antialiasing aa = Camera.main.GetComponent<Antialiasing>();
            if (aa != null)
                aa.enabled = false;

            foreach (Bloom item in blooms) {
                item.quality = Bloom.BloomQuality.Cheap;
            }
        }
    }
}