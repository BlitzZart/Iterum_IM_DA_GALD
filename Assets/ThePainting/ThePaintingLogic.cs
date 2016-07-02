using UnityEngine;
using System.Collections;

public class ThePaintingLogic : MonoBehaviour {

    private Camera paintingCam;
    private GameObject painting;

    private HiResScreenShots hiResShot;

    private bool inProgress = false;
    public bool makeLiveScreenshot = false;

    // Use this for initialization
    void Start() {
        paintingCam = GetComponentInChildren<Camera>();
        painting = GetComponentInChildren<MeshRenderer>().gameObject;

        if (makeLiveScreenshot)
            painting.SetActive(false);
        paintingCam.gameObject.SetActive(false);
        hiResShot = GetComponent<HiResScreenShots>();
    }

    void MsgPlayerEntered(GameObject player) {
        if (!makeLiveScreenshot || inProgress)
            return;

        inProgress = true;

        paintingCam.gameObject.SetActive(true);

        // try some perspective correction
        Vector3 camPos = paintingCam.transform.position;
        //camPos.z = camPos.z - (camPos.z - Camera.main.transform.position.z) * 3;
        //paintingCam.transform.Rotate(0, (camPos.z - Camera.main.transform.position.z) * -17.0f, 0);

        paintingCam.transform.position = camPos;

        hiResShot.TakeHiResShot();

        InvokeRepeating("WaitForImage", 0.1f, 0.1f);


    }

    void WaitForImage() {
        if (hiResShot.thePainting != null) {
            painting.GetComponent<MeshRenderer>().material.mainTexture = hiResShot.thePaintingRT;
            painting.SetActive(true);
            Destroy(paintingCam.gameObject);
            CancelInvoke("WaitForImage");
        }
    }
}
