using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fire : MonoBehaviour
{
    public Animator animator;
    private PlayerInput playerInput;

    void Update()
    {
        //for firing animationg trigger to true then false again
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            animator.SetTrigger("Firing");
        }
        else
        {
            animator.ResetTrigger("Firing");
        }


    }
}
