using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBehaviour : MonoBehaviour
{
    private BombFSM bomb;
    private Grenade grenade;

    void Start()
    {
        bomb = GetComponent<BombFSM>();
        grenade = GetComponent<Grenade>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sword") || collision.gameObject.CompareTag("Bullet"))
        {
            bomb.HP--;
            bomb.CheckIfAlive(); 
        }else if (collision.gameObject.CompareTag("grenade") && grenade.animator.GetBool("Explosion") == true)
        {
            bomb.HP -= 2;
        }
    }
}
