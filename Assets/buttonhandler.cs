using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonhandler : MonoBehaviour
{
    public void VRButtonClick()
    {
        SceneManager.LoadScene("MobileVR1");
    }
    public void ARButtonClick()
    {
        SceneManager.LoadScene("MobileAR");
       // SceneManager.LoadScene("MobileAR");

    }
    public void InfoButtonClick()
    {
       
    }


}
