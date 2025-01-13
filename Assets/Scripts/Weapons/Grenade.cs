using System.Collections;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float lifetime = 1f;
    public float bounciness = 0.6f;
    public PhysicsMaterial2D bounceMaterial;
    public float explosionDuration = 2f;

    private Collider2D grenadeCollider;
    public Collider2D explosionCollider;
    public Animator animator;
    private Rigidbody2D rb;
    private float lifeTimer;
    private bool isExploding = false;
    private float pushForce = 0.5f;

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

        if (explosionCollider != null)
        {
            explosionCollider.enabled = false;
        }
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

        if (explosionCollider != null)
        {
            explosionCollider.enabled = true;
        }

        animator.SetBool("Explosion", true);
        AudioManager.audioManager.PlayBoom();

        yield return new WaitForSeconds(explosionDuration);

        if (explosionCollider != null)
        {
            explosionCollider.enabled = false;
        }

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

        if (explosionCollider != null)
        {
            explosionCollider.enabled = false;
        }

        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IHurteable>(out var enemy) && animator.GetBool("Explosion"))
        {
            enemy.Hurt(2);
            push(transform.position, collision.gameObject.GetComponent<Rigidbody2D>());
        }
    }

    public void push(Vector2 origin, Rigidbody2D target)
    {
        if (target == null) return;

        
        Vector2 pushDirection = (target.position - origin).normalized;

        
        target.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
    }
}
