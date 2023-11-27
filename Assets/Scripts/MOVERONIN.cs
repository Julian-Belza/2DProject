using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVERONIN : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public Ronin ronin;
    public idek idek;
    public Animator anim;

    public float speed = 2.5f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    private void Start()
    {

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    private void Update()
    {
        ronin.LookAtPlayer();
        if (!idek.backingOff)
        {
            anim.SetBool("Idle", false);
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }

        if (idek.backingOff)
        {
            Vector2 target = new Vector2(0.0f, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
            anim.SetBool("Idle", true);
        }
    }
}
