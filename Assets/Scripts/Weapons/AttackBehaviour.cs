using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackBehaviour : MonoBehaviour, Inputs.IWeaponActions
{
    private Animator animator;
    private Inputs weaponAttack;
    private Melee sword;

    private
    void Start()
    {
       animator = GetComponent<Animator>();
        weaponAttack = new Inputs();
        weaponAttack.Weapon.SetCallbacks(this);
        sword = GetComponent<Melee>();
    }

    // Update is called once per frame
    void Update()
    {
        sword.OnAttack();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        animator.SetBool("Attack", true);
    }
}
