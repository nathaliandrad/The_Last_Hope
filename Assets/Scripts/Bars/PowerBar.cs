using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradientColor;
    public Image fill;


    public void SetMaxPowerValue(int power)
    {
        slider.maxValue = power;
        slider.value = power;

        fill.color = gradientColor.Evaluate(1f);

    }

    public void SetPowerUp(int power)
    {
            slider.value = power;
            fill.color = gradientColor.Evaluate(slider.normalizedValue);
    }

}
