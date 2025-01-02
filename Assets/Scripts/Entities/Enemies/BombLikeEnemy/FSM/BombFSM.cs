using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFSM : MonoBehaviour
{
    public List<StatesSO<BombFSM>> states;
    public StatesSO<BombFSM> CurrentState;
    public float HP;
    public GameObject coin;
    public int coinDropCount = 1;
    public GameObject target;
    private Animator animator;
    private Rigidbody2D rb;
    private Collider2D collider2D;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
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
            collider2D.enabled = false;
            animator.SetBool("ColPlayer", true);
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            GoToState<ExplodeState>();
            DropCoins();
            
        }
    }

    private void DropCoins()
    {
        for (int i = 0; i < coinDropCount; i++)
        {
            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-1f, 1f),
                0.5f
            );

            Instantiate(coin, randomPosition, Quaternion.identity);
        }
    }

    public void GoToState<T>() where T : StatesSO<BombFSM>
    {
        if (CurrentState.StatesToGo.Find(state => state is T))
        {
            CurrentState.OnStateExit(this);
            CurrentState = CurrentState.StatesToGo.Find(obj => obj is T);
            CurrentState.OnStateEnter(this);
        }
    }
}
