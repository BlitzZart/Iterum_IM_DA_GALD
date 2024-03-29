﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDeformer : MonoBehaviour, ISwitchable {
    static Vector3 unInitVec = new Vector3(-9999.1f, -9999.2f, -9999.3f); // TODO: make clean initialisation - this init value is just a hack
    class Vertex {
        public Vector3 tVertex;
        public Vector3 oVertex;
        public Vector3 normal;
        public List<int> indices;

        public Vertex() {
            indices = new List<int>();
            tVertex = new Vector3(unInitVec.x, unInitVec.y, unInitVec.z);
        }

        public Vertex(Vector3 vertex, Vector3 normal, int index) {
            this.tVertex = vertex;
            this.oVertex = vertex;
            this.normal = normal;

            indices = new List<int>();
            indices.Add(index);
        }

        public void AddIndex(int index, Vector3 normal) {
            indices.Add(index);
            this.normal = (this.normal + normal) / 2;
        }

        public override string ToString() {
            string text = "@ Vertex: ";
            text += tVertex + "\n";
            text += " Indices: ";
            foreach (int item in indices) {
                text += item + " ";
            }
            return text;
        }
    }

    class VertexList {
        public List<Vertex> vertices;
        public VertexList() {
            vertices = new List<Vertex>();
        }

        public void Add(Vertex vertex) {
            vertices.Add(vertex);
        }

        public void TryAddIndex(Vector3 vertex, Vector3 normal, int index) {
            foreach (Vertex item in vertices)
                if (item.tVertex == vertex)
                    item.AddIndex(index, normal);

        }

        public bool Contains(Vector3 vertex) {
            foreach (Vertex item in vertices)
                if (item.tVertex == vertex)
                    return true;
            return false;
        }

        public override string ToString() {
            string text = "Length " + vertices.Count + "  \n";
            foreach (Vertex item in vertices) {
                text += item.ToString();
            }
            return text;
        }
    }

    public bool solidDeformation = true;
    public bool relaxMesh = false;
    public bool reactOnPlayerDistance = false;
    [Range(0.0f, 10)]
    public float reactionDistance = 5;

    bool positiveDeformation = true;

    Mesh mesh;
    Vector3[] targetVertices;
    Vector3[] oV;

    Vertex[] unique;
    VertexList uList;

    float[] offsets;

    [Header("Overall power of deformation")]
    [Range(0.0f, 50)]
    public float power = 1.0f;
    [Header("Influence of FFT")]
    [Range(0.0f, 10)]
    public float fftPower = 1.0f;
    [Header("Noise floor")]
    [Range(0.0f, 10.0f)]
    public float randomPower = 1.0f;
    [Header("Speed of linear interpolation")]
    [Range(0.0f, 25.0f)]
    public float speed = 1.0f;
    [Header("Update rate of animation")]
    [Range(0.0f, 1.0f)]
    public float rate = 0.1f; // for music visualization beat detection would be nice

    public GameObject positionSource;

    private float defaultVibration = 0.02f;

    // used for player position independend deformation 
    private Transform playerTransform;
    private Vector3 playerPosition;
    private float playerDistance;


    // Use this for initialization
    void Start() {
        mesh = GetComponent<MeshFilter>().mesh;
        mesh.MarkDynamic();

        // prepare datastructure for solid mesh deformation
        List<Vector3> rV = new List<Vector3>();
        rV.Add(mesh.vertices[0]);
        for (int i = 1; i < mesh.vertices.Length; i++) {
            if (!rV.Contains(mesh.vertices[i])) {
                rV.Add(mesh.vertices[i]);
            }
        }
        uList = new VertexList();
        for (int i = 0; i < mesh.vertexCount; i++) {
            if (!uList.Contains(mesh.vertices[i])) {
                uList.Add(new Vertex(mesh.vertices[i], mesh.normals[i], i));
            }
            else {
                uList.TryAddIndex(mesh.vertices[i], mesh.normals[i], i);
            }
        }
        unique = uList.vertices.ToArray();

        //print(uList.ToString());

        oV = mesh.vertices;
        targetVertices = mesh.vertices;
        offsets = new float[] { 0 };

        playerTransform = positionSource.transform;
    }

    public void ArrayOffests(float[] offsets) {

        this.offsets = ModifyFFT(offsets);
    }

    private float[] ModifyFFT(float[] s) {
        for (int i = 0; i < s.Length; i++) {
            s[i] *= 100;
            s[i] = Mathf.Clamp(s[i], 0, 0.22f);
        }
        return s;
    }

    private float current = 0;
    // Update is called once per frame
    void Update() {
        if (current < rate) {
            current += Time.deltaTime;
        }
        else {
            current = 0;

            if (solidDeformation)
                UpdateMeshSolid();
            else
                UpdateMeshBreaking();
        }

        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < oV.Length; i++) {
            //if (positiveDeformation & targetVertices[i].sqrMagnitude < 0)
            //    targetVertices[i] *= -1;
            vertices[i] = Vector3.Lerp(vertices[i], targetVertices[i], Time.deltaTime * speed);
        }
        mesh.vertices = vertices;
        mesh.RecalculateBounds();
    }

    void UpdateMeshBreaking() {
        for (int i = 0; i < oV.Length; i++) {
            targetVertices[i] = oV[i] + mesh.normals[i] * UnityEngine.Random.Range(-randomPower, randomPower) * power *
                (defaultVibration * Mathf.Clamp01(power) + offsets[i % offsets.Length] * fftPower);
        }
    }

    void UpdateMeshSolid() {
        if (!reactOnPlayerDistance) {
            playerDistance = reactionDistance = 1; // prevent division by zero
        }
        //else {
        //    // check distance between gameobject and player.
        //    // skip if far away to save prevents useless processing.
        //    // TODO: solve relaxing problem. 
        //    if (Vector3.Distance(playerTransform.transform.position, transform.position) > reactionDistance + 5)
        //        return;
        //}

        // transfrom player position in mesh(local) space
        playerPosition = transform.InverseTransformPoint(playerTransform.transform.position);
        int i = 0;
        foreach (Vertex item in unique) {
            playerDistance = Vector3.Distance(playerPosition, item.oVertex);

            float randInfluence;
            if (randomPower > 0)
                randInfluence = UnityEngine.Random.Range(-randomPower, randomPower);
            else
                randInfluence = 1;


            // calculate position of target vertex
            item.tVertex = 
                item.oVertex + item.normal *
                randInfluence *
                power *
                (reactionDistance / playerDistance) *
                (defaultVibration * Mathf.Clamp01(power) + offsets[i++ % offsets.Length] * fftPower);

            if (reactOnPlayerDistance) { // vertices react on player position
                if (playerDistance < reactionDistance) {
                    UpdateTargetVertices(item, false);
                }
                else { // reset mesh if player walks away
                    UpdateTargetVertices(item, true);
                }
            }
            else { // this happens when player position check is deactivated
                UpdateTargetVertices(item, relaxMesh);
            }
        }
    }

    // use this to deactivate the mesh deformer delayed
    // so the mesh can relax when the player is gone
    IEnumerator DeactivateDelayed() {
        yield return new WaitForSeconds(1);
        // set mesh deformer inactive
        this.enabled = false;
    }

    // apply new position to all target vertices
    void UpdateTargetVertices(Vertex vertex, bool relax) {
        if (relax)
            foreach (int index in vertex.indices)
                targetVertices[index] = vertex.oVertex;

        else // reset mesh if player walks away
            foreach (int index in vertex.indices)
                targetVertices[index] = vertex.tVertex;
    }

    public void Activate() {
        this.enabled = true;
    }

    public void DeActivate() {
        StartCoroutine(DeactivateDelayed());
    }

    public void Switch() {
        this.enabled = !this.enabled;
    }

    public bool GetState() {
        return this.enabled;
    }
}