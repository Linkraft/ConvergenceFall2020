using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class ClickHandler : MonoBehaviour
{

    public UnityEvent upEvent;
    public UnityEvent downEvent;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        Debug.Log("Down");
        downEvent?.Invoke();
    }

    // Update is called once per frame
    void OnMouseUp()
    {
        Debug.Log("Up");
        upEvent?.Invoke();

    }
}
