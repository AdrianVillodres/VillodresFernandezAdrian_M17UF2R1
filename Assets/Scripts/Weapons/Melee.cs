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
    public float pushForce = 10f;


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


    private void Attack()
    {
        if (InputManager.Pause)
        {
            return;
        }
        animator.SetTrigger("Attack");
        StartCoroutine(EnableColliderTemporarily());
    }

    private IEnumerator EnableColliderTemporarily()
    {
        if (swordCollider != null)
        {
            swordCollider.enabled = true;
            yield return new WaitForSeconds(0.5f);
            swordCollider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent<IHurteable>(out var enemy))
        {
            enemy.Hurt(1);
            Push(transform.position, other.GetComponent<Rigidbody2D>());
        }
    }

    public void Push(Vector2 origin, Rigidbody2D target)
    {
        if (target == null) return;
        Vector2 pushDirection = (target.position - origin).normalized;
        target.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
        StartCoroutine(StopPush(target));
    }

    IEnumerator StopPush(Rigidbody2D target)
    {
        yield return new WaitForSeconds(1f);
        target.velocity = Vector2.zero;
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
