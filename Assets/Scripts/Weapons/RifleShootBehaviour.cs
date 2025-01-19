using UnityEngine;
using UnityEngine.InputSystem;

public class RifleShootBehaviour : MonoBehaviour, Inputs.IWeaponActions
{
    private Inputs ic;
    public Transform firePoint;
    public float fireRate = 0.1f;

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
        GameObject bullet = FindAnyObjectByType<BulletPool>().Pop();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
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
            AudioManager.audioManager.PlayShoot();
            fireTimer = fireRate;
        }
    }

    public void OnChange(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
