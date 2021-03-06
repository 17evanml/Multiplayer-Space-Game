﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorGameManager : MonoBehaviour
{
    public static CursorGameManager Instance { get; private set; }
    public GameObject testCup;

    //Client side buttons
    public GameObject canvas;
    public RectTransform canvasRectTransform;
    public RectTransform buttonParent;
    public Button offClick;
    public Button poisonClick;
    public Button fakeClick;
    public Vector2 offset;

    public GUIStyle textStyle;

    private void Awake()
    {
        canvas.SetActive(true);
        canvas.SetActive(false);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SwapPillPosition()
    {
        if (Random.Range(0, 2) == 1) {
            Debug.Log("Randomly swapping pill position.");
            Vector3 temp = poisonClick.transform.position;
            poisonClick.transform.position = fakeClick.transform.position;
            fakeClick.transform.position = temp;
        }
    }

    private void CreateCup(CursorManager cm)
    {
        GameObject g = Instantiate(testCup);

        // // This Part does not do anything
        // Debug.Log("Before: " + g.GetComponent<Renderer>().materials[0].color);
        // g.GetComponent<Renderer>().materials[0].color = cm.cursorColor;
        // Debug.Log("After: " + g.GetComponent<Renderer>().materials[0].color);

        // This part Sets the Entire Mesh to be one Color
        var block = new MaterialPropertyBlock();
        block.SetColor("_BaseColor", cm.cursorColor);
        g.GetComponent<Renderer>().SetPropertyBlock(block);

        CupInfo c = g.GetComponent<CupInfo>();
        if (c)
        {
            c.Initialize(cm.id, cm.name, cm.cursorColor);
            c.color = cm.cursorColor;
        }
        GameManager.instance.AddCup(c);
    }

    public void CreateAllCups()
    {
        foreach (CursorManager cm in GameManager.cursors.Values)
        {
            CreateCup(cm);
        }

    }

    public void NextTurn()
    {
        //this needs to be called for all players
    }
}
