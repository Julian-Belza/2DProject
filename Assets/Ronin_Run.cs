using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ronin_Run : StateMachineBehaviour
{
    Transform player;
    Transform resetPoint;
    Rigidbody2D rb;
    public float speed = 2;
    public float attackRange = 3;

    Ronin ronin;
    Enemy enemy;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
        resetPoint = GameObject.FindGameObjectWithTag("ResetPoint").transform;
       rb = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<Enemy>();

       ronin = animator.GetComponent<Ronin>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemy.isAttacking)
        {
            ronin.LookAtPlayer();
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        } else if (!enemy.isAttacking)
        {
            ronin.LookAtPoint();
            Vector2 target = new Vector2(resetPoint.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
