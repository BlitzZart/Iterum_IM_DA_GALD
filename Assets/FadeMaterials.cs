using UnityEngine;

public class FadeMaterials : MonoBehaviour
{
    private Renderer m_renderer;

    private void Start()
    {
        m_renderer = GetComponent<Renderer>();
    }

    public void ShortBlack()
    {
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", 0.0f, "to", 1.0f,
            "time", 0.1f, "easetype", "linear",
            "onupdate", "setAlpha"));

        iTween.ValueTo(gameObject, iTween.Hash(
            "from", 1.0f, "to", 0.0f,
            "time", 0.2f, "easetype", "linear",
            "onupdate", "setAlpha"));
    }
    public void FadeOut(float duration = 3.0f)
    {
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", 0.0f, "to", 1.0f,
            "time", duration, "easetype", "linear",
            "onupdate", "setAlpha"));
    }
    public void FadeIn(float duration = 3.0f)
    {
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", 1.0f, "to", 0.0f,
            "time", duration, "easetype", "linear",
            "onupdate", "setAlpha"));
    }

    public void setAlpha(float newAlpha)
    {
        foreach (Material mObj in m_renderer.materials)
        {
            mObj.color = new Color(
                mObj.color.r, mObj.color.g,
                mObj.color.b, newAlpha);
        }
    }

}