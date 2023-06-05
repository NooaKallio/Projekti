using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;       // Refrenssi slideriin
    public Gradient healthGradient;   // Refrenssi gradient osaan
    public Image hpBarImage;          // Refrenssi hp bar kuvaan

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        // sliderin max value
        healthSlider.maxValue = maxHealth;

        // sliderin current value
        healthSlider.value = currentHealth;

        
        float fillAmount = currentHealth / maxHealth;

        // värin muuttaminen damagen ottamisen aikana
        hpBarImage.color = healthGradient.Evaluate(fillAmount);
    }
}
