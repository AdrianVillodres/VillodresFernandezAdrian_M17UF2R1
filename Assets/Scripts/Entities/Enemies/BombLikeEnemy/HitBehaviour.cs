using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBehaviour : MonoBehaviour
{
    private Bomb bomb;
    Animator animator;
    private bool isDestroying = false;
    void Start()
    {
        bomb = GetComponent<Bomb>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDestroying)
        {
            if (bomb.life <= 0)
            {
                animator.SetBool("ColPlayer", true);
                animator.SetBool("SeePlayer", false);
                isDestroying = true;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            bomb.life--;
        }
    }
}
