using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToHeadGlue : MonoBehaviour {
    private Transform head;
    public float translationSpeed = 10;
    public float rotationSpeed = 10;

    private void Start()
    {
        head = Camera.main.transform;

        // move to head pos
        transform.position = head.position;

        // set canvas as child
        Transform canvas = FindObjectOfType<Canvas>().transform;
        canvas.parent = transform;

        // set rotation
        transform.rotation = head.rotation;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, head.position, translationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, head.rotation, rotationSpeed * Time.deltaTime);
    }
}
