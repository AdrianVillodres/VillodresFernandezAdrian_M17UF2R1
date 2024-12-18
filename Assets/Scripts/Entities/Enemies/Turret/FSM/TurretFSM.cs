using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TurretFSM : MonoBehaviour
{
    public List<StatesSO<TurretFSM>> states;
    public StatesSO<TurretFSM> CurrentState;
    public int HP;
    private Animator animator;
    private Rigidbody2D rb;
    public EnemyBulletPool eBullet;


    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        CurrentState.OnStateUpdate(this);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GoToState<ShootState>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GoToState<IdleStateTurret>();
        }
    }

    public void CheckIfAlive()
    {
        if (HP < 1)
        {
            animator.SetBool("Die", true);
            GoToState<DieState>();
        }
    }

    public void GoToState<T>() where T : StatesSO<TurretFSM>
    {
        if (CurrentState.StatesToGo.Find(state => state is T))
        {
            CurrentState.OnStateExit(this);
            CurrentState = CurrentState.StatesToGo.Find(obj => obj is T);
            CurrentState.OnStateEnter(this);
        }
    }
}
