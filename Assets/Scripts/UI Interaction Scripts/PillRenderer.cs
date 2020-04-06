﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Visual Representation of a Pill. </summary>
public class PillRenderer : MonoBehaviour {
    public Pill pill; // Pill Data
    public MeshRenderer bottomCapsule, topCapsule;
    public Material mat;


    // private Material bottom, top; // Seperate Sprite Renderers for Bottom and Top Capsules

    // Start is called before the first frame update
    void Start() {

        // bottomCapsule.gameObject.transform.GetComponent<Renderer>().material.color = Color.red;
        // mat.SetColor("_Color", pill.pillColor);

        // bottomCapsule.material.SetColor("_Color", pill.pillColor);

        var block = new MaterialPropertyBlock();
        block.SetColor("_BaseColor", pill.pillColor);
        bottomCapsule.gameObject.GetComponent<Renderer>().SetPropertyBlock(block);

        block.SetColor("_BaseColor", pill.playerColor);
        topCapsule.gameObject.GetComponent<Renderer>().SetPropertyBlock(block);
        
        

        // topCapsule.material.SetColor("_Color", Color.red);
    }

    void Update() {
        Debug.Log(topCapsule.material.name);
        Debug.Log(topCapsule.material.color);
    }
}
