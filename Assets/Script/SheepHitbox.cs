using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Hitbox : MonoBehaviour
{
    public int animalHp = 100;
    public int currentHp;
    public Animator animator;
    public Animal animal;
    private Shoot shot;
    

    public Player player;
    public QuestGoal goal;
    public AnimalHealth health;
    public QuestGiver giver;
    AudioControl audioManager;


    public GameObject tranqPanel;
    public GameObject syringePanel;
    private int healAnimal = 0;
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
            tranqPanel.SetActive(true);
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
            //trigger syringe panels
            if (healAnimal == 0)
            {
                syringePanel.SetActive(true);
                healAnimal++;
            }
            
            //revive animation
            animator.SetTrigger("healed");
            animal.StartCoroutine(animal.WaitToMove());
            audioManager.PlaySFX(audioManager.InjectionHeal);
            player.gold += 10;
            goal.AnimalHealed();
            


        }
        animal.health = animalHp;
        health.SetHealth(animalHp);
    }
    
    /*private IEnumerator HealPerSecond()
    {
        for (currentHp = 0; currentHp <= 100; currentHp += 10)
        {
            animalHp = currentHp;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        animalHp = 100;
    }*/
}
