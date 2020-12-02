using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GoogleARCore.Examples.HelloAR
{
    public class LockButton : MonoBehaviour
    {
        public Sprite[] sprites;
        public GameObject icon;
        HelloARController hc;

        void Start()
        {
            hc = FindObjectOfType<HelloARController>();
            hc.unlocked = false;
        }

        public void UpdateLock()
        {
            // Switch to opposite state of lock
            hc.unlocked = !hc.unlocked;
            if (hc.unlocked) icon.GetComponent<Image>().sprite = sprites[1];
            else icon.GetComponent<Image>().sprite = sprites[0];
        }
    }
}