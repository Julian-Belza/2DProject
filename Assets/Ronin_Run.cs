/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ronin_Run : StateMachineBehaviour
{
    Transform player;
    Transform resetPoint;
    Rigidbody2D rb;
    public float speed = 20.0f;

    float nextAttack = 5.0f;
    float cooldown;

    Ronin ronin;
    Enemy enemy;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        resetPoint = GameObject.FindGameObjectWithTag("ResetPoint").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<Enemy>();
        ronin = animator.GetComponent<Ronin>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cooldown += Time.deltaTime;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    void AttackPlayer()
    {
        Vector2 target = new Vector2.MoveTowards(transform.position, player.position, speed);
    }
}
*/