using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FlamethrowerDamage : MonoBehaviour
{
    public ParticleSystem flamethrowerParticles;

    void Start()
    {
        var collisionModule = flamethrowerParticles.collision;
        collisionModule.enabled = true;
        collisionModule.type = ParticleSystemCollisionType.World;
        collisionModule.sendCollisionMessages = true;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Bomb"))
        {
            BombFSM bomb = other.GetComponent<BombFSM>();
            Debug.Log("¡Colisión con enemigo detectada!");
            bomb.HP = bomb.HP-0.1f;
            bomb.CheckIfAlive();
        }
        else if (other.CompareTag("Turret"))
        {
            TurretFSM turret = other.GetComponent<TurretFSM>();
            Debug.Log("¡Colisión con enemigo detectada!");
            turret.HP = turret.HP-0.1f;
            turret.CheckIfAlive();
        }
    }
}
