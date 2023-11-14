using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Potion : MonoBehaviour
{
    [SerializeField] private float healthValue;

    public HeroKnight HeroKnight;

    public TMP_Text potionText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            HeroKnight.m_potions++;
            gameObject.SetActive(false);
        } else {
            return;
        }
    }

    private void Update()
    {
        potionText.text = HeroKnight.m_potions.ToString();
    }
}
