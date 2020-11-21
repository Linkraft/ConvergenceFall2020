using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class StartVR : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        XRSettings.enabled = true;
    }

    private void Update()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
