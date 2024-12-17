using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBehaviour : MonoBehaviour
{
    private BombFSM bomb;
    void Start()
    {
        bomb = GetComponent<BombFSM>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sword") || collision.gameObject.CompareTag("Bullet"))
        {
            bomb.HP--;
            bomb.CheckIfAlive();
        }
    }
}
