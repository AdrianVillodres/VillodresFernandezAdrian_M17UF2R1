using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeShootBehaviour : MonoBehaviour
{
    public Transform firePoint;
    public float fireRate = 0.1f;

    private float fireTimer;

    void Update()
    {
        fireTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRate;
        }
    }

    private void Shoot()
    {
        GameObject Grenade = GrenadePool.pool.Pop();
        Grenade.transform.position = firePoint.position;
        Grenade.transform.rotation = firePoint.rotation;
    }
}
