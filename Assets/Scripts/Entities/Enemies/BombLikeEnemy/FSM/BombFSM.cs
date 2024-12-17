using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFSM : MonoBehaviour
{
    public List<StatesSO> states;
    public StatesSO CurrentState;
    public int HP;
    public GameObject target;
    private Animator animator;
    private Rigidbody2D rb;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            target = collision.gameObject;
            animator.SetBool("SeePlayer", true);
            GoToState<ChaseState>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GoToState<IdleState>();
            animator.SetBool("SeePlayer", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("ColPlayer", true);
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            GoToState<ExplodeState>();
        }
    }

    private void Update()
    {
        CurrentState.OnStateUpdate(this);
    }

    public void CheckIfAlive()
    {
        if (HP < 1)
        {
            animator.SetBool("ColPlayer", true);
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            GoToState<ExplodeState>();
        }
    }

    public void GoToState<T>() where T : StatesSO
    {
        if (CurrentState.StatesToGo.Find(state => state is T))
        {
            CurrentState.OnStateExit(this);
            CurrentState = CurrentState.StatesToGo.Find(obj => obj is T);
            CurrentState.OnStateEnter(this);
        }
    }
}
