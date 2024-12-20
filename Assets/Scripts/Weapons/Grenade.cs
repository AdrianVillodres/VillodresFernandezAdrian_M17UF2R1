using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;
    public float bounciness = 0.6f; 
    public PhysicsMaterial2D bounceMaterial; 

    private Rigidbody2D rb;
    private float lifeTimer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();


        if (bounceMaterial == null)
        {
            bounceMaterial = new PhysicsMaterial2D();
            bounceMaterial.bounciness = bounciness;
            bounceMaterial.friction = 0f;
        }

        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.sharedMaterial = bounceMaterial;
        }
    }

    void OnEnable()
    {
        lifeTimer = lifetime;
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
            ResetGrenade();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ResetGrenade();
        }
    }

    private void ResetGrenade()
    {
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        GrenadePool.pool.Push(gameObject);
    }
}
