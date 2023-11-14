using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherEnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
            {
                DirectionChange();
            }
        }
    }

    private void OnDisable()
    {
        anim.SetBool("Walk", false);
    }

    private void DirectionChange()
    {
        anim.SetBool("Walk", false);

        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;

        anim.SetBool("Walk", true);

        enemy.localScale = new Vector3(initScale.x * _direction * -1, initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
        enemy.position.y, enemy.position.z);
    }
}