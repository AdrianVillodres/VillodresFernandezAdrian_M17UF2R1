using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrenadeShootBehaviour : MonoBehaviour, Inputs.IWeaponActions
{
    private Inputs ic;
    public Transform firePoint;
    public float fireRate = 0.1f;
    public float grenadeForce;

    private float fireTimer = 0f;

    private void Awake()
    {
        ic = new Inputs();
        ic.Weapon.SetCallbacks(this);
    }

    private void OnEnable()
    {
        ic.Enable();
    }

    private void OnDisable()
    {
        ic.Disable();
    }

    void Update()
    {
        if (fireTimer > 0)
        {
            fireTimer -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        GameObject grenade = FindAnyObjectByType<GrenadePool>().Pop();
        grenade.transform.position = firePoint.position;
        grenade.transform.rotation = firePoint.rotation;


        Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 direction = firePoint.right.normalized;
            rb.velocity = direction * grenadeForce;
        }
    }


    public void OnShoot(InputAction.CallbackContext context)
    {
        if (InputManager.Pause)
        {
            return;
        }
        if (context.performed && fireTimer <= 0)
        {
            Shoot();
            fireTimer = fireRate;
        }
    }

    public void OnChange(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
