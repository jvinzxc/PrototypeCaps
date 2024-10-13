using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEditor;

public class PigHitbox : MonoBehaviour
{
    public int animalHp = 100;
    public int currentHp;
    public Animator animator;
    private Animal animal;
    private Shoot shot;
    [SerializeField] private TextMeshProUGUI CurrentCoins;
    [SerializeField] private GameObject Coins;

    public QuestManagement quest;

    public AnimalHealth health;
    AudioControl audioManager;

    void Start()
    {
        animal = GetComponent<Animal>();
        shot = GetComponent<Shoot>();
        currentHp = animalHp;
        health.SetMaxHealth(animalHp);
    }
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioControl>();
    }
    public void TakeDamage(int damageAmount)
    {
        animalHp -= damageAmount;
        if (animalHp <= 0)
        {
            //sleep animation
            animator.SetTrigger("sleep");

            //GetComponent<Animal>().enabled = false;
            animal.health = 0;
            animal.StopAllCoroutines();
            animal.StartCoroutine(animal.StopMoving());
            //animal.enabled = false;
        }
        else
        {
            //damage animation
            animator.SetTrigger("damage");
        }
        animal.health = animalHp;
        health.SetHealth(animalHp);
    }
    public void Heal(int healAmount)
    {
        animalHp += healAmount;

        if (animalHp > 100)
        {
            animalHp = 100;
        }
        if (animalHp == 100)
        {
            //revive animation
            animator.SetTrigger("healed");
            animal.StartCoroutine(animal.WaitToMove());
            audioManager.PlaySFX(audioManager.InjectionHeal);

        }
        animal.health = animalHp;
        health.SetHealth(animalHp);
    }
}
