using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FlamethrowerDamage : MonoBehaviour
{
    public ParticleSystem flamethrowerParticles;  // Referencia al sistema de part�culas

    void Start()
    {
        // Configurar el sistema de part�culas para enviar mensajes de colisi�n
        var collisionModule = flamethrowerParticles.collision;
        collisionModule.enabled = true;
        collisionModule.type = ParticleSystemCollisionType.World;
        collisionModule.sendCollisionMessages = true;  // Esto habilita OnParticleCollision
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Bomb"))  // Comprobar si la colisi�n es con un enemigo
        {
            BombFSM bomb = other.GetComponent<BombFSM>();  // Obtener el componente BombFSM del enemigo


            Debug.Log("�Colisi�n con enemigo detectada!");
            bomb.HP--;
            bomb.CheckIfAlive();


        }
        else if (other.CompareTag("Turret"))
        {
            TurretFSM turret = other.GetComponent<TurretFSM>();
            Debug.Log("�Colisi�n con enemigo detectada!");
            turret.HP--;
            turret.CheckIfAlive();
        }
    }
}
