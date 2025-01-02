using System.Collections;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float lifetime = 1f;
    public float bounciness = 0.6f;
    public PhysicsMaterial2D bounceMaterial;
    public float explosionDuration = 0.5f;

    private Collider2D grenadeCollider;
    private Animator animator;
    private Rigidbody2D rb;
    private float lifeTimer;
    private bool isExploding = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        grenadeCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();

        if (bounceMaterial == null)
        {
            bounceMaterial = new PhysicsMaterial2D
            {
                bounciness = bounciness,
                friction = 0f
            };
        }

        grenadeCollider.sharedMaterial = bounceMaterial;
    }

    void OnEnable()
    {
        ResetState();

        if (rb != null)
        {
            Vector2 direction = transform.right.normalized;
            rb.velocity = direction;
        }
    }

    void Update()
    {
        if (isExploding) return;

        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0)
        {
            StartCoroutine(Explode());
        }
    }

    private IEnumerator Explode()
    {
        isExploding = true;

        
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }


        grenadeCollider.enabled = false;

        animator.SetBool("Explosion", true);

        yield return new WaitForSeconds(explosionDuration);
        animator.SetBool("Explosion", false);

        ResetGrenade();
    }

    private void ResetGrenade()
    {
        ResetState();

        if (GrenadePool.pool != null)
        {
            animator.SetBool("Explosion", false);
            GrenadePool.pool.Push(gameObject);
        }
        else
        {
            animator.SetBool("Explosion", false);
            Destroy(gameObject);
        }
    }

    private void ResetState()
    {
        lifeTimer = lifetime;
        isExploding = false;

        if (animator != null)
        {
            animator.SetBool("Explosion", false);
            animator.Play("Idle", 0, 0f);
        }

        if (grenadeCollider != null)
        {
            grenadeCollider.enabled = true;
        }

        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}
