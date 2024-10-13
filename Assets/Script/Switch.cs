using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Switch : MonoBehaviour
{
    InputAction switching;
    public int items = 0;
    public TextMeshProUGUI ammoInfoText1;
    public GameObject TextInfo1;
    public GameObject TextInfo2;
    public GameObject Inventory1;
    public GameObject Inventory2;
    public GameObject Inventory3;
    public TextMeshProUGUI ammoInfoText2;

    // Start is called before the first frame update
    void Start()
    {
        switching = new InputAction("Scroll", binding: "<Mouse>/scroll");
        switching.AddBinding("<Gamepad>/Dpad");
        switching.Enable();

        foreach(Transform weapon in transform)
        {
            weapon.gameObject.SetActive(false);

        }
        transform.GetChild(items).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Shoot currentGun = FindObjectOfType<Shoot>();
        Heal currentHeal = FindObjectOfType<Heal>();

        if (currentGun != null)
        {
            TextInfo1.SetActive(true);
            TextInfo2.SetActive(false);
            ammoInfoText1.text = "Ammo:" + currentGun.currentAmmo + " / " + currentGun.magazineSize;
        }
        float scrollValue = switching.ReadValue<Vector2>().y;
        int preItems = items;

        if (currentHeal)
        {
            TextInfo2.SetActive(true);
            TextInfo1.SetActive(false);
            ammoInfoText2.text = "Heal:" + currentHeal.currentHeal + " / " + currentHeal.healSize;
        }
        
        if (scrollValue > 0)
        {
            items++;
            if(items == 3)
                items = 0;
        }else if(scrollValue < 0)
        {
            items--;
            if(items == -1)
                items = 2;
        }
        if(preItems != items)
            Items();

        if (items == 0)
        {
            Inventory1.SetActive(true);
            Inventory2.SetActive(false);
            Inventory3.SetActive(false);
        }
        else if (items == 1)
        {
            Inventory2.SetActive(true);
            Inventory3.SetActive(false);
            Inventory1.SetActive(false);
        }
        else if (items == 2)
        {
            Inventory3.SetActive(true);
            Inventory1.SetActive(false);
            Inventory2.SetActive(false);
        }
    }
    private void Items()
    {
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(false); 
        }
        transform.GetChild(items).gameObject.SetActive(true);
    }
}
