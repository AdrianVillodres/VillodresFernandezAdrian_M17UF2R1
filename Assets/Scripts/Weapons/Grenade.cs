using System.Collections;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;
    public float bounciness = 0.6f;
    public PhysicsMaterial2D bounceMaterial;
    private Collider2D grenadeCollider;
    private Animator animator;
    private Rigidbody2D rb;
    private float lifeTimer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        grenadeCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();

        if (bounceMaterial == null)
        {
            bounceMaterial = new PhysicsMaterial2D();
            bounceMaterial.bounciness = bounciness;
            bounceMaterial.friction = 0f;
        }

        grenadeCollider.sharedMaterial = bounceMaterial;
    }

    void OnEnable()
    {
        lifeTimer = lifetime;
        grenadeCollider.enabled = true;

        if (rb != null)
        {
            Vector2 direction = transform.right.normalized;
            rb.velocity = direction * speed;
        }
    }

    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0)
        {
            StartCoroutine(Explode());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

            animator.SetBool("Explosion", true);
            rb.freezeRotation = true;
            StartCoroutine(Explode());
        
    }

    private IEnumerator Explode()
    {
        grenadeCollider.enabled = false;
        yield return new WaitForSeconds(1f);
        animator.SetBool("Explosion", false);
        ResetGrenade();
    }

    private void ResetGrenade()
    {
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
        grenadeCollider.enabled = false;
        GrenadePool.pool.Push(gameObject);
    }
}
