using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frames
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Left Click Detected");
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left DownClick detected");
        }
        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("Right UpClick Detected");
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right DownClick Detected");
        }

    }
}
