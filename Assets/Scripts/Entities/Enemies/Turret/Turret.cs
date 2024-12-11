using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    Animator animator;
    public float life;
    public Transform player;
    public EnemyBulletPool eBullet;
    public float detectionRange = 150f;
    public float shootCooldown = 1f;
    private bool isDestroying = false;
    private float shootTimer;

    void Start()
    {
        animator = GetComponent<Animator>();
        shootTimer = shootCooldown;
    }

    void Update()
    {
        if (!isDestroying)
        {
            if (player != null && eBullet != null)
            {
                DetectAndShoot();
            }
        }
    }

    private void DetectAndShoot()
    {
        Vector3 distance = player.position - transform.position;
        float distanceMagnitude = distance.magnitude;

        if (distanceMagnitude <= detectionRange)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                ShootAtPlayer();
                shootTimer = shootCooldown;
            }
        }
    }

    private void ShootAtPlayer()
    {
        GameObject bullet = eBullet.Pop();
        if (bullet != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
    }
}
