using UnityEngine;
using UnityEngine.InputSystem;

public class Flamethrower : MonoBehaviour, Inputs.IWeaponActions
{
    public ParticleSystem flameParticles;  // El sistema de part�culas del lanzallamas
    private Inputs ic;

    void Awake()
    {
        ic = new Inputs();
        ic.Weapon.SetCallbacks(this);
    }

    private void OnEnable()
    {
        ic.Enable();

        if (flameParticles.isPlaying)
        {
            flameParticles.Stop();
        }
    }

    private void OnDisable()
    {
        ic.Disable();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!flameParticles.isPlaying)
            {
                flameParticles.Play();  // Iniciar las part�culas
            }
        }
        else if (context.canceled)
        {
            if (flameParticles.isPlaying)
            {
                flameParticles.Stop();  // Detener las part�culas
            }
        }
    }

    public void OnChange(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
