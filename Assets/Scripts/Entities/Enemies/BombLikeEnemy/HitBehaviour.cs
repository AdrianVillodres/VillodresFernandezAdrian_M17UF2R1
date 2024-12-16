using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBehaviour : MonoBehaviour
{
    private BombFSM bomb;
    Animator animator;
    private bool isDestroying = false;
    void Start()
    {
        bomb = GetComponent<BombFSM>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {         
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sword") || collision.gameObject.CompareTag("Bullet"))
        {
            bomb.HP--;
        }
    }
}
