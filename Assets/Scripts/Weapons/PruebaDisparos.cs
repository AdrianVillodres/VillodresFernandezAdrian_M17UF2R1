using UnityEngine;

public class Weapon : MonoBehaviour
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
        GameObject bullet = BulletPool.pool.Pop();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
    }
}