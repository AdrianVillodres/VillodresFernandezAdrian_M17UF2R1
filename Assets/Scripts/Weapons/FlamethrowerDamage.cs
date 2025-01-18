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
        if (other.gameObject.TryGetComponent<IHurteable>(out var enemy))
        {
            enemy.Hurt(0.05f);
        }
    }
}
