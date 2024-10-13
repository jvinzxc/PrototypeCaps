using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHealth : MonoBehaviour
{
    public Slider slider;
    public Gradient gridient;
    public Image Fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        Fill.color = gridient.Evaluate(1f);
    }
    
    public void SetHealth(int health)
    {
        slider.value = health;

        Fill.color = gridient.Evaluate(slider.normalizedValue);
    }
}
