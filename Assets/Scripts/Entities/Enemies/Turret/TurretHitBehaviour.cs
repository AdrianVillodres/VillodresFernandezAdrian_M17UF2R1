using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHitBehaviour : MonoBehaviour
{
    private TurretFSM turret;
    void Start()
    {
        turret = GetComponent<TurretFSM>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sword") || collision.gameObject.CompareTag("Bullet"))
        {
            turret.HP--;
            turret.CheckIfAlive();
        }
    }
}
