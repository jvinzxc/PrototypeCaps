using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;
using UnityEngine.UI;
using TMPro;

public class Shoot : MonoBehaviour
{
    public PlayerLook look;

    public Animator animator;
    public Transform WeaponCamera;
    public float range = 20f;
    public float impactForce = 150f;
    public int damageAmount = 50;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public int fireRate = 10;
    private float nextTimeToFire = 1;
    public int currentAmmo;
    public int maxAmmo = 5;
    public int magazineSize = 5;
    public bool isReloading;
    public float reloadTime = 2f;

    InputAction shoot;
    public bool isFire;
    public bool isRealoading;
    AudioControl audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioControl>();
    }

    // Start is called before the first frame update
    void Start()
    {
        shoot = new InputAction("Shoot", binding: "<mouse>/leftButton");
        shoot.AddBinding("<Gamepad>/x");

        shoot.Enable();

        currentAmmo = maxAmmo;
    }
    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmmo == 0 && magazineSize == 0)
        { 
            animator.SetBool("Scoped", false);
            return;
        }
        if (isReloading)
        {
            return;
        }        
        bool isShooting = shoot.ReadValue<float>() == 1;
        if (isShooting && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Fire();
        }
        if (currentAmmo == 0 && magazineSize > 0 && !isReloading)
        {
            look.ySensitivity = 7f;
            look.xSensitivity = 7f;
            StartCoroutine(Reload());
        }
        if(isFire) 
        {
            Fire();
        }
        if (isRealoading)
        {
            Reload();
        }
    }
    public void Fire()
    {
        currentAmmo--;
        muzzleFlash.Play();
        audioManager.PlaySFX(audioManager.SniperShoot);
        RaycastHit hit;
        if (Physics.Raycast(WeaponCamera.position, WeaponCamera.forward, out hit, range))
        {
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
                damageAmount = 5;
            }

            Hitbox box = hit.transform.GetComponent<Hitbox>();
            if(box != null)
            {
               box.TakeDamage(damageAmount);
                return;
            }
            Quaternion impactRotation = Quaternion.LookRotation(hit.normal);
            GameObject impact = Instantiate(impactEffect, hit.point, impactRotation);
            impact.transform.parent = hit.transform;
            Destroy(impact, 5);
        }
      
    }
    IEnumerator Reload()
    {
        isReloading = true;
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime);
        animator.SetBool("Reloading", false);
        if(magazineSize >= maxAmmo)
        {
            currentAmmo = maxAmmo;
            magazineSize -= maxAmmo;
            
        }
        else
        {
            currentAmmo = magazineSize;
            magazineSize = 0;
        }
        isReloading = false;
    }
}
