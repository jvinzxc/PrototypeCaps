using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Heal : MonoBehaviour
{
    public Animator animator;
    public Transform WeaponCamera;
    public float range = 20f;
    public float impactForce = 150f;
    public int healAmount = 10;
    public ParticleSystem muzzleFlash;

    private int fireRate = 10;
    private float nextTimeToFire = 1;

    public int currentHeal;
    public int maxHeal = 1;
    public int healSize = 25;
    public bool isReloading;
    public float reloadTime = 2f;


    InputAction shoot;

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

        currentHeal = maxHeal;
    }
    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }
    // Update is called once per frame
    void Update()
    {
        if (currentHeal == 0 && healSize == 0)
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
        if (currentHeal == 0 && healSize > 0 && !isReloading)
        {
            StartCoroutine(Reload());
        }
    }
    private void Fire()
    {
        currentHeal--;
        muzzleFlash.Play();
        audioManager.PlaySFX(audioManager.InjectionSound);
        RaycastHit hit;
        if (Physics.Raycast(WeaponCamera.position, WeaponCamera.forward, out hit, range))
        {
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
                healAmount = 5;
            }

            Hitbox box = hit.transform.GetComponent<Hitbox>();
            if (box != null)
            {
                box.Heal(healAmount);
                return;
            }
            //Quaternion impactRotation = Quaternion.LookRotation(hit.normal);
            //GameObject impact = Instantiate(impactEffect, hit.point, impactRotation);
            //impact.transform.parent = hit.transform;
            //Destroy(impact, 5);

        }
    }
    IEnumerator Reload()
    {
        isReloading = true;
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime);
        animator.SetBool("Reloading", false);
        if (healSize >= maxHeal)
        {
            currentHeal = maxHeal;
            healSize -= maxHeal;
        }
        else
        {
            currentHeal = healSize;
            healSize = 0;
        }
        isReloading = false;
    }
}
