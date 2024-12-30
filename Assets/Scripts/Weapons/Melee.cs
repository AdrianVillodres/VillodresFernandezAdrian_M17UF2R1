using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Melee : MonoBehaviour, Inputs.IWeaponActions
{
    private Animator animator;
    private Collider2D swordCollider;
    private Inputs ic;

    private bool isAttacking = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
        swordCollider = GetComponent<Collider2D>();
        ic = new Inputs();
        ic.Weapon.SetCallbacks(this);
        swordCollider.enabled = false;
    }

    private void OnEnable()
    {
        ic.Enable();
    }

    private void OnDisable()
    {
        ic.Disable();
    }


    private void Update()
    {
        animator.SetBool("Attack", isAttacking);
    }

    private void Attack()
    {
        isAttacking = true;
        StartCoroutine(EnableColliderTemporarily());
    }

    private IEnumerator EnableColliderTemporarily()
    {
        if (swordCollider != null)
        {
            swordCollider.enabled = true;
            yield return new WaitForSeconds(0.5f);
            swordCollider.enabled = false;
            isAttacking = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemigo golpeado!");
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Attack();
        }
    }

    public void OnChange(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
