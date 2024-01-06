using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    public void UpdateHealthBar(float currentHp, float maxHp)
    {
        healthSlider.value = currentHp/maxHp;
    }
    private void Update()
    {
        
    }
}
