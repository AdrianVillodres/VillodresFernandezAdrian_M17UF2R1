using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Animator animator;
    public string animationStateName;
    public Transform player;
    public float life;
    public float speed;
    private bool isDestroying = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SeePlayer();

        if (isDestroying)
        {
            CheckAnimationAndDestroy();
        }
    }

    private void SeePlayer()
    {
        animator.SetBool("SeePlayer", true);
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * speed * Time.deltaTime);

        if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("ColPlayer", true);
            isDestroying = true;
        }
    }
    private void CheckAnimationAndDestroy()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName(animationStateName) && stateInfo.normalizedTime >= 1f)
        {
            Destroy(gameObject);
        }
    }
}
