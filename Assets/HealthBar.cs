using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static System.Net.Mime.MediaTypeNames;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    //start avec la vie max
    void Start()
    {
        SetMaxHealth((int)slider.maxValue);
        SetHealth((int)slider.value);
    }

    //modificateyr vie max
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        //met les valeur dans le champs text "HealthValue"
        transform.Find("HealthValue").GetComponent<Text>().text = health.ToString() + " / " + slider.maxValue.ToString();
    }

    //modificateur vie
    public void SetHealth(int health)
    {
        slider.value = health;
        
        //met les valeur dans le champs text "HealthValue"
        transform.Find("HealthValue").GetComponent<Text>().text = health.ToString() + " / " + slider.maxValue.ToString();
    }
}
