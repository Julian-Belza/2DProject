using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private PlayerHealth playerHealth;

    // Start is called before the first frame update
    public void SetHealth(float health)
    {
        slider.value = health;
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    private void Start()
    {
        SetMaxHealth(playerHealth.startingHealth);
    }

    private void Update()
    {
        SetHealth(playerHealth.currentHealth);
    }
}
