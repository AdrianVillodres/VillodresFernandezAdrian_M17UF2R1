using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackBehaviour : MonoBehaviour, Inputs.IWeaponActions
{
    private Animator animator;
    private Inputs weaponAttack;

    private
    void Start()
    {
        animator = GetComponent<Animator>();
        weaponAttack = new Inputs();
        weaponAttack.Weapon.SetCallbacks(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        animator.SetBool("Attack", true);
    }

    public void OnChange(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
