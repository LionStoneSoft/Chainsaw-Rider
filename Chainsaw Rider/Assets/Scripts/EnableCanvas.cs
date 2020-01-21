using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCanvas : MonoBehaviour
{
    public GameObject canvas;

    public void Start()
    {
        canvas.SetActive(false);
    }

    public void canvasActivated()
    {
        canvas.SetActive(true);
    }
}
