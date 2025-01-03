using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHitBehaviour : MonoBehaviour
{
    private TurretFSM turret;
    private Grenade grenade;
    void Start()
    {
        turret = GetComponent<TurretFSM>();
        grenade = GetComponent<Grenade>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sword") || collision.gameObject.CompareTag("Bullet"))
        {
            turret.HP--;
            turret.CheckIfAlive();
        }
        else if (collision.gameObject.CompareTag("grenade") && grenade.animator.GetBool("Explosion") == true)
        {
            turret.HP -= 2;
        }
    }
}
