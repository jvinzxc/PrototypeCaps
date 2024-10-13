using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Scope : MonoBehaviour
{
    public Animator animator;
    public Shoot shot;

    //default value so that i would not scope form the start
    private bool isScoped = false;

    public GameObject ScopeOverlay;
    public GameObject Crosshair;
    public Camera MainCamera;
    public GameObject Map;
    public GameObject Pause;
    public GameObject Inventory;
    public GameObject Quest;
    public GameObject Coins;
    public GameObject Ammo;
    public GameObject InventoryButton;
    public GameObject MissionButton;
    public GameObject TutorialButton;
    public GameObject AlmanacButton;
    public GameObject ScopeButton;


    InputAction scope;
    //public float ScopeFov = 10f;
    //private float NormalFov;

    void Start()
    {
        scope = new InputAction("Scope", binding: "<mouse>/rightButton");
        
        scope.Enable();
    }
    void Update()
    {
        Shoot shot = FindAnyObjectByType<Shoot>();
        if (shot.isReloading || shot.currentAmmo == 0)
        {
            OnUnscoped();
            
        }
        else
        {
            if (scope.triggered)
            {
                isScoped = !isScoped;
                if (isScoped)
                {
                    StartCoroutine(OnScoped());
                }
                else
                {
                    OnUnscoped();
                }
            }
        }

    }   
    IEnumerator OnScoped()
    {
        animator.SetBool("Scoped", true);
        //animator.SetBool("Run", false);
        
        yield return new WaitForSeconds(.25f);
        ScopeOverlay.SetActive(true);
        Crosshair.SetActive(false);
        Map.SetActive(false);
        Pause.SetActive(false);
        Inventory.SetActive(false);
        Coins.SetActive(false);
        Quest.SetActive(false);
        Ammo.SetActive(false);
        InventoryButton.SetActive(false);
        MissionButton.SetActive(false);
        AlmanacButton.SetActive(false);
        TutorialButton.SetActive(false);
        MainCamera.fieldOfView = 10;
        MainCamera.cullingMask = MainCamera.cullingMask & ~(1 << 7);
    }
    void OnUnscoped()
    {
        animator.SetBool("Scoped", false);
        ScopeOverlay.SetActive(false);
        Crosshair.SetActive(true);
        Map.SetActive(true);
        Pause.SetActive(true);
        Inventory.SetActive(true);
        Coins.SetActive(true);
        Quest.SetActive(true);
        Ammo.SetActive(true);
        InventoryButton.SetActive(true);
        MissionButton.SetActive(true);
        AlmanacButton.SetActive(true);
        TutorialButton.SetActive(true);
        MainCamera.fieldOfView = 60;
        MainCamera.cullingMask = MainCamera.cullingMask | (1 << 7);
    }
    //old code
    /*private void Update()
    {
        
        //if rightclick is pressed it would trigger it.
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            isScoped = !isScoped;
            animator.SetBool("Scoped", isScoped);

            if (isScoped)
            {
                StartCoroutine(OnScoped());
            }
            else
            {
                OnUnscoped();
            }
        }
        void OnUnscoped()
        {
            ScopeOverlay.SetActive(false);
            WeaponCamera.SetActive(true);
            Crosshair.SetActive(true);

            MainCamera.fieldOfView = NormalFov;
        }
        IEnumerator OnScoped()
        {
            yield return new WaitForSeconds(.15f);
            ScopeOverlay.SetActive(true);
            WeaponCamera.SetActive(false);
            Crosshair.SetActive(false);

            NormalFov = MainCamera.fieldOfView;
            MainCamera.fieldOfView = ScopeFov;
        }
    }*/
}
