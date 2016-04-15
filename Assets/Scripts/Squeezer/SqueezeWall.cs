using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using System;

public class SqueezeWall : MonoBehaviour, ISwitchable {

    public float max, min;

    private float speed = 10.0f;
    private bool isVisible = true;
    private bool doSqueeze;

    private float stepWidth = 0.3f;
    private float minDistanceToPlayer = 2.6f;

    public SqueezeWall opposite;

    Renderer renderComp;
    FirstPersonController fpsC;

    void Start () {
        fpsC = FindObjectOfType<FirstPersonController>();
        renderComp = GetComponent<Renderer>();
	}
	
    void OnWillRenderObject() {
        isVisible = true;
    }
    void OnBecameInvisible() {
        isVisible = false;
    }
    void OnBecameVisible() {
        isVisible = true;
    }

    void Update() {
        // translate towards player if not visible
        // also let the player push if not visible (by moving backwards - towards the wall) 

        // only if squeeze is enabled
        if (!doSqueeze)
            return;

        if (isVisible)
            return;
        // check minimum distance to player
        if (Mathf.Abs(transform.position.z - fpsC.transform.position.z + stepWidth) > minDistanceToPlayer) {
            // wall can follows if min distance
            Vector3 newPosition = GetNewPositionByLerping(speed);
            transform.position = newPosition;
        }
        else { // pushing is allowed
            Vector3 newPosition = GetNewPositionByMoving(-speed);
            transform.position = newPosition;
        }
    }

    // instant position change
    private Vector3 GetNewPositionBySetting() {
        float newZ = fpsC.transform.position.z + (minDistanceToPlayer * Mathf.Sign(transform.position.z - fpsC.transform.position.z));
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, newZ);
        // only move if the wall would remain between min an max values - adding ((Time.deltaTime * speed) + minMaxTolerance) do prevent dead lock
        if (newPosition.z < min || newPosition.z > max)
            return transform.position;

        return newPosition;
    }

    // walls approach by a certain speed - using Lerp (the missuse with a constant t decreases the speed of the wall when it approaches the player)
    private Vector3 GetNewPositionByLerping(float wallSpeed) {
        Vector3 newPosition = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, fpsC.transform.position.z - stepWidth), Time.deltaTime * wallSpeed);
        // only move if the wall would remain between min an max values - adding ((Time.deltaTime * speed) + minMaxTolerance) do prevent dead lock
        if (newPosition.z < min || newPosition.z > max)
            return transform.position;

        return newPosition;
    }

    // walls approach by a certain speed - using MoveTorwards
    private Vector3 GetNewPositionByMoving(float wallSpeed) {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, fpsC.transform.position.z - stepWidth), Time.deltaTime * wallSpeed);
        // only move if the wall would remain between min an max values - adding ((Time.deltaTime * speed) + minMaxTolerance) do prevent dead lock
        if (newPosition.z < min || newPosition.z > max)
            return transform.position;

        return newPosition;
    }

    public void Activate() {
        doSqueeze = true;
    }

    public void DeActivate() {
        doSqueeze = false;
    }

    public void Switch() {
        doSqueeze = !doSqueeze;
    }

    public bool GetState() {
        return doSqueeze;
    }
}
