using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapLoadLevel : MonoBehaviour
{
    public string levelToLoad;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Application.LoadLevel(levelToLoad);
        }
    }
}
