using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreScript : MonoBehaviour
{
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = gameManager.health;
        slider.value = slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function that changes the slider on the core appropiatly
    public void TakeDamage(int damage)
    {
        slider.value = gameManager.health - damage;
    }
}
