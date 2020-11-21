using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class StopVR : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        XRSettings.enabled = false;
    }

    private void Update()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
