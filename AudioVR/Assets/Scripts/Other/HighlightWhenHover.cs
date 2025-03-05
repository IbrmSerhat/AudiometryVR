using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HighlightWhenHover : MonoBehaviour
{
    public Color OriginalColor, StoredColor; 
    private Renderer Renderer;
    void Awake()
    {
        Renderer = GetComponent<Renderer>();
        OriginalColor = Renderer.material.color;
        StoredColor = OriginalColor;
    }

    void Start()
    {

    }

    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        Renderer.material.color = Color.red;
    }

    public void OnHoverExited(HoverExitEventArgs args)
    {
        Renderer.material.color = OriginalColor;
    }

    public void Hold()
    {
        if (OriginalColor != Color.blue) OriginalColor = Color.blue;
        else OriginalColor = StoredColor;

        if (Renderer.material.color != Color.red) Renderer.material.color = OriginalColor;
    }
}
