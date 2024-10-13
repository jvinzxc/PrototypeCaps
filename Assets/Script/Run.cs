using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class Run : MonoBehaviour
{
    public Animator animator;
    private bool isRunning = false;
    private void Update()
    {
        if (Keyboard.current.shiftKey.wasPressedThisFrame)
        {
            isRunning = !isRunning;
            animator.SetBool("Run",isRunning);
            
        }
        
    }
}
