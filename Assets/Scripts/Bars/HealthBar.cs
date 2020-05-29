using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //getting slider component
    public Slider slider;
    public Gradient gradientColor;
    public Image fill;

    //setting player max health different than enemy
    public void SetPlayerMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        //evaluating color value
        fill.color = gradientColor.Evaluate(1f);
        
    }

    //setting current health to player
    public void SetPlayerHealth(int health)
    {
        slider.value = health;
        fill.color = gradientColor.Evaluate(slider.normalizedValue) ;
    }


}
