using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemy : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;

    [Header ("Collider Parameters")]
    [SerializeField] private float colliderDistance;

    [Header ("Player Layer")]
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    public Animator animator;

    private PlayerHealth playerHealth;
    public HeroKnight HeroKnight;
    public AudioSource BlockingNoise;
    private HeavyPatrol enemyPatrol;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<HeavyPatrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                animator.SetTrigger("Attack");
            }
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 
        0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<PlayerHealth>();
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight() && !HeroKnight.isBlocking)
        {
            playerHealth.TakeDamage(damage);
        } else if (PlayerInSight() && HeroKnight.isBlocking)
        {
            HeroKnight.m_animator.SetBool("Blocked", true);
            StartCoroutine(Blocked(.45f));
            BlockingNoise.Play();
            playerHealth.TakeDamage(damage / 10);
        }
    }

    IEnumerator Blocked(float delay)
    {
        yield return new WaitForSeconds(delay);

        HeroKnight.m_animator.SetBool("Blocked", false);
    }
}
