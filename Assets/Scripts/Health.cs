using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] public float startingHealth;
    public float currentHealth { get; private set;}
    [SerializeField] public int score;

    private Animator anim;
    public bool dead;

    public HeroKnight HeroKnight;
    Rigidbody2D rb;

    [Header ("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header ("components")]
    [SerializeField] private Behaviour[] components;
    public AudioSource HitNoise;
    private void Awake()
    {
        currentHealth = startingHealth;

        anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();

        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0 , startingHealth);

        if (currentHealth > 0)
        {
            HitNoise.Play();
            if (!HeroKnight.isBlocking)
            {
                anim.SetTrigger("Hurt");
                StartCoroutine(standStill());
                StartCoroutine(invulnerability());
            } else if (HeroKnight.isBlocking)
            {
                HeroKnight.m_animator.SetBool("IdleBlock", true);
            }
        } else 
        {
            if (!dead)
            {
                anim.SetTrigger("Death");
                HeroKnight.totalScore += score;
                Debug.Log(HeroKnight.totalScore);
                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }
                dead = true;
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public IEnumerator invulnerability()
    {
        Physics2D.IgnoreLayerCollision(6,7, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1,1,1, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(6,7, false);
    }

    IEnumerator standStill()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;

        yield return new WaitForSeconds(1.0f);

        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
