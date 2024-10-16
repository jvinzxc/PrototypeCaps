using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FixedButtonFire : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool FirePressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        FirePressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        FirePressed = false;
    }
}
