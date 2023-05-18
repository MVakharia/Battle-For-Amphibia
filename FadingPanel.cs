using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingPanel : MonoBehaviour
{
    private void Awake()
    {
        Color c = gameObject.GetComponent<Renderer>().material.color;

        c = new Color(c.r, c.g, c.b, 1);
    }
}
