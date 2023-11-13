using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] private float healthValue;

    public HeroKnight HeroKnight;

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
}
