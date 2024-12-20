using UnityEngine;
using UnityEngine.InputSystem;

public class FlamethrowerController : MonoBehaviour, Inputs.IWeaponActions
{
    public ParticleSystem flameParticles;
    private Inputs ic;

    private void Awake()
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

    void Update()
    {

    }


    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!flameParticles.isPlaying)
            {
                flameParticles.Play();
            }
        }
        else if (context.canceled)
        {
            if (flameParticles.isPlaying)
            {
                flameParticles.Stop();
            }
        }
    }

    public void OnChange(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
