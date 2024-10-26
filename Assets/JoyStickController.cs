using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class JoyStickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image joystickBackground;
    private Image joystick;
    private Vector2 inputVector;

    void Start()
    {
        joystickBackground = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground.rectTransform, eventData.position, eventData.pressEventCamera, out position))
        {
            position.x = (position.x / joystickBackground.rectTransform.sizeDelta.x);
            position.y = (position.y / joystickBackground.rectTransform.sizeDelta.y);

            inputVector = new Vector2(position.x * 2, position.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            // Move the joystick knob
            joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (joystickBackground.rectTransform.sizeDelta.x / 2), inputVector.y * (joystickBackground.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float Horizontal()
    {
        return inputVector.x;
    }

    public float Vertical()
    {
        return inputVector.y;
    }
}
