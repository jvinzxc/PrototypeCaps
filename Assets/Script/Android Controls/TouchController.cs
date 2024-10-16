using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public FixedTouchField fixedTouchField;
    public CameraLook cameraLook;
    public AndroidMovement androidMovement;
    public FixedButton fixedButton;

    public FixedButtonFire fixedButtonFire;
    public PlayerFire playerFire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraLook.LockAxis = fixedTouchField.TouchDist;
        //androidMovement.Pressed = fixedButton.Pressed;
        //playerFire.isPassed = fixedButtonFire.FirePressed;
    }
    
}
