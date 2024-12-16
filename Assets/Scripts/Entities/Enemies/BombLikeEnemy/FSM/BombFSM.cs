using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFSM : MonoBehaviour
{
    public List<StatesSO> states;
    public StatesSO CurrentState;
    public int HP;
    public GameObject target;
    private ChaseBehaviour chasebehaviour;
    private Animator animator;
    private void Start()
    {
        chasebehaviour = GetComponent<ChaseBehaviour>();
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        target = collision.gameObject;
        animator.SetBool("SeePlayer", true);
        GoToState<ChaseState>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GoToState<IdleState>();
        animator.SetBool("SeePlayer", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("ColPlayer", true) ;
        GoToState<ExplodeState>();
    }

    private void Update()
    {
        CurrentState.OnStateUpdate(this);
        CheckIfAlive();
    }

    public void CheckIfAlive()
    {
        if (HP < 1)
            GoToState<ExplodeState>();
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
