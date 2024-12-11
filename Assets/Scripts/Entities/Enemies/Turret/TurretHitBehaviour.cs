using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHitBehaviour : MonoBehaviour
{
    private Turret turret;
    Animator animator;
    private bool isDestroying = false;
    void Start()
    {
        turret = GetComponent<Turret>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDestroying)
        {
            if (turret.life <= 0)
            {
                isDestroying = true;
            }
        }
        else
        {
            GameObject.Destroy(turret.gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sword") || collision.gameObject.CompareTag("Bullet"))
        {
            turret.life--;
        }
    }
}
