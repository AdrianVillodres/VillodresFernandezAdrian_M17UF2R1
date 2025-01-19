using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretFSM : MonoBehaviour, IHurteable
{
    public List<StatesSO<TurretFSM>> states;
    public StatesSO<TurretFSM> CurrentState;
    public float HP;
    public GameObject key;
    public int KeyDropCount = 1;
    private Animator animator;
    private Rigidbody2D rb;
    public EnemyBulletPool eBullet;
    public GameObject healthSlider;


    void Start()
    {
        animator = GetComponent<Animator>();
        healthSlider.SetActive(false);
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
            DropKey();
        }
    }

    private void DropKey()
    {
        for (int i = 0; i < KeyDropCount; i++)
        {
            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-1f, 1f),
                0.5f,
                Random.Range(-1f, 1f)
            );

            Instantiate(key, randomPosition, Quaternion.identity);
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
