using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretFSM : MonoBehaviour
{
    public List<StatesSO<TurretFSM>> states;
    public StatesSO<TurretFSM> CurrentState;
    public float HP;
    public GameObject coin;
    public int coinDropCount = 1;
    private Animator animator;
    private Rigidbody2D rb;
    public EnemyBulletPool eBullet;
    private Slider healthSlider;
    private bool healthBarVisible = false;


    void Start()
    {
        animator = GetComponent<Animator>();
        healthSlider = GetComponentInChildren<Slider>();
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        HP = Mathf.Clamp(HP, 0, healthSlider.maxValue);

        if (healthSlider != null)
        {
            healthSlider.value = HP;
        }

        CheckIfAlive();
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

            GetComponent<Collider2D>().enabled = false;
            animator.SetBool("Die", true);
            GoToState<DieState>();
            DropCoins();
        }
    }

    private void DropCoins()
    {
        for (int i = 0; i < coinDropCount; i++)
        {
            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-1f, 1f),
                0.5f,
                Random.Range(-1f, 1f)
            );

            Instantiate(coin, randomPosition, Quaternion.identity);
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
