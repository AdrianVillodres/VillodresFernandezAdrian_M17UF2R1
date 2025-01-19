using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;

    private float lifeTimer;

    void OnEnable()
    {
        lifeTimer = lifetime;
    }

    void Update()
    {
        
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0)
        {
            FindAnyObjectByType<BulletPool>().Push(gameObject);
        }
    }

    private void ResetGrenade()
    {

        if (FindAnyObjectByType<GrenadePool>().stack != null)
        {
            FindAnyObjectByType<BulletPool>().Push(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb") || collision.gameObject.CompareTag("Turret"))
        {
            FindAnyObjectByType<BulletPool>().Push(gameObject);
        }
        if (collision.gameObject.TryGetComponent<IHurteable>(out var enemy))
        {
            enemy.Hurt(1);
        }

    }
}
