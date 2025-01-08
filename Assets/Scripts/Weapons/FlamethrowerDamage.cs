using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FlamethrowerDamage : MonoBehaviour
{

    void Start()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Bomb"))
        {
            BombFSM bomb = other.GetComponent<BombFSM>();
            bomb.CheckIfAlive();
            bomb.TakeDamage(0.05f);
        }
        else if (other.CompareTag("Turret"))
        {
            TurretFSM turret = other.GetComponent<TurretFSM>();
            turret.CheckIfAlive();
            turret.TakeDamage(0.05f);
        }
    }
}
