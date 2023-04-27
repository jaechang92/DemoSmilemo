using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFrame : MonoBehaviour
{
    private Vector2 referenceResolution = new Vector2(1920, 1080);
    private GameObject canvas;
    private CanvasScaler canvasScaler;
    [SerializeField]
    private bool onCommonUI;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        canvas = Finder.FindGameObject("Canvas");

        try
        {
            canvasScaler = canvas.GetComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = referenceResolution;
        }
        catch (Exception e)
        {
            Debug.LogError("canvasScaler " + e);
        }

        if (onCommonUI)
        {
            GameObject obj = Resources.Load("Common/CommonPannel") as GameObject;
            Instantiate(obj, canvas.transform);
        }

    }

}
