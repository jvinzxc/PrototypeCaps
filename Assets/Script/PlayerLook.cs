using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerLook : MonoBehaviour
{
    public Slider slider;
    public Camera cam;
    private float xRotation = 0f;

    //Initial Default Value
    public float defaultyValue = 7f;
    public float defaultxValue = 7f;
    public float ySensitivity = 10f;  
    public float xSensitivity = 10f;
    private bool isScope = false;

    private void Start()
    {
        ySensitivity = defaultyValue;
        xSensitivity = defaultxValue;

        if(slider != null)
        {
            slider.value = ySensitivity * xSensitivity;
        }

    }

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        //calculate camera position for looking up and down
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //apply this to our camera transform.
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //rotate look left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
    public void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            isScope = !isScope;
            if (isScope)
            {
                ySensitivity = 2f;
                xSensitivity = 2f;
                if(slider != null)
                {
                    slider.value = ySensitivity * xSensitivity;
                }
            }
            else
            {
                ySensitivity = defaultyValue;
                xSensitivity = defaultxValue;
                if (slider != null)
                {
                    slider.value = ySensitivity * xSensitivity;
                }
            }
        }
        if(slider != null)
        {
            float sensitivityMultiplier = slider.value / (defaultyValue * defaultxValue);
            ySensitivity = defaultyValue * sensitivityMultiplier;
            xSensitivity = defaultxValue * sensitivityMultiplier;
        }
    }
}
