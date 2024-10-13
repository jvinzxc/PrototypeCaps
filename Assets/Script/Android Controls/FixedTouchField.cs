using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class FixedTouchField : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
{
    public Vector2 TouchDist;
    public Vector2 PointerOld;
    protected int PointerID;
    public bool Pressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Pressed)
        {
            if(PointerID >= 0 && PointerID < Input.touches.Length)
            {
                TouchDist = Input.touches[PointerID].position - PointerOld;
                PointerOld = Input.touches[PointerID].position;
            }
            else
            {
                TouchDist = new Vector2 (Input.mousePosition.x, Input.mousePosition.y) - PointerOld;
                PointerOld = Input.mousePosition;
            }
        }
        else
        {
            TouchDist = new Vector2();
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        PointerID = eventData.pointerId;
        PointerOld = eventData.position;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }
}
