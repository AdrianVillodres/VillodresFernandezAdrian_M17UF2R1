using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BombFSM : MonoBehaviour, IHurteable
{
    public List<StatesSO<BombFSM>> states;
    public StatesSO<BombFSM> CurrentState;
    public float HP;
    public GameObject coin;
    public int coinDropCount = 1;
    public GameObject target;
    private Animator animator;
    private Collider2D collider2D;
    public GameObject healthSlider;


    public bool notInRoom = false;

    private void Start()
    {
        coinDropCount = Random.Range(1, 3);
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
        healthSlider.SetActive(false);
    }

    private void Update()
    {
        if (!notInRoom)
        {
            CurrentState.OnStateUpdate(this); 
        }
    }

    public void CheckIfAlive()
    {
        if (HP < 0.5f)
        {
            collider2D.enabled = false;
            animator.SetBool("ColPlayer", true);
            GoToState<ExplodeState>();
            Drop();
        }
    }


    private void Drop()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            target = collision.gameObject;
            if(target != null)
            {
                animator.SetBool("SeePlayer", true);
            }
            GoToState<ChaseState>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GoToState<IdleState>();
            if (target != null)
            {
                animator.SetBool("SeePlayer", false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent<IHurteable>(out var player))
            {
                player.Hurt(1);
            }
            animator.SetBool("ColPlayer", true);
            GoToState<ExplodeState>();
        }
    }

    public void Hurt(float damage)
    {
        healthSlider.SetActive(true);
        HP -= damage;
        HP = Mathf.Clamp(HP, 0, healthSlider.GetComponent<Slider>().maxValue);
        if (healthSlider != null)
        {
            healthSlider.GetComponent<Slider>().value = HP;
        }
        CheckIfAlive();
    }
}
