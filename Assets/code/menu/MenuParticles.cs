using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuParticles : MonoBehaviour {

    ParticleEmitter pEmitter;
    ParticleRenderer pRenderer;

    void OnLevelWasLoaded(int level) {
        if (SceneManager.GetActiveScene().name.Contains("lobby"))
            SetParticlesActive(false);
        if (SceneManager.GetActiveScene().name.Contains("MenuMain"))
            SetParticlesActive(true);
    }

    void SetParticlesActive(bool value) {
        pEmitter.enabled = value;
        pRenderer.enabled = value;
    }

    void Start() {
        pEmitter = GetComponent<ParticleEmitter>();
        pRenderer = GetComponent<ParticleRenderer>();
        DontDestroyOnLoad(transform.gameObject);
    }
}
