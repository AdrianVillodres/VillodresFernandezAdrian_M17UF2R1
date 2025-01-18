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
            BulletPool.pool.Push(gameObject);
        }
    }

    private void OnDisable()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb") || collision.gameObject.CompareTag("Turret"))
        {
            BulletPool.pool.Push(gameObject);
        }
        if (collision.gameObject.TryGetComponent<IHurteable>(out var enemy))
        {
            enemy.Hurt(1);
        }

    }
}
