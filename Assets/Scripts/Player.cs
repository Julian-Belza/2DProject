using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Potion":
                GetComponent<HeroKnight>().m_potions[0]++;
                Debug.Log(GetComponent<HeroKnight>().m_potions[0]);
                other.gameObject.SetActive(false);
                break;

            case "Win":
                Debug.Log("u won good job i guess");
                break;
        }
    }
}
