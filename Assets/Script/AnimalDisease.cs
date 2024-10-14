using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalDisease : MonoBehaviour
{

    public Button bton;
    // Update is called once per frame

    private int showMessage = 0;
    private bool isPressed = false;
    public GameObject panel;
    void Start()
    {
        showMessage = 0;
        bton.onClick.AddListener(OnButtonClick);
    }
    void Update()
    {
        if(showMessage > 0)
        {
            Destroy(panel);
        }
    }
    void OnButtonClick()
    {
        if (!isPressed)
        {
            showMessage++;
            isPressed = true;
        }
    }
}
