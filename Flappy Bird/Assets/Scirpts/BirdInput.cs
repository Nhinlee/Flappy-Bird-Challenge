using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class BirdInput : MonoBehaviour
{
    // Bird Input Field
    bool isReadyToClearInput;
    [HideInInspector] public bool isInputTap;

    private void FixedUpdate()
    {
        // Flag to hold state of input 
        // Guarentee each frame can take input rightway.
        isReadyToClearInput = true;
    }

    private void Update()
    {
        if (isReadyToClearInput)
        {
            ResetInput();
        }
        ProcessInput();
    }

    private void ProcessInput()
    {
        isInputTap = isInputTap || Input.GetButtonDown("Jump");
    }

    private void ResetInput()
    {
        isInputTap = false;
        // Set flag ready clear to false
        isReadyToClearInput = false;
    }
}
