using UnityEngine;

public class Grenade : MonoBehaviour
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
            GrenadePool.pool.Push(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GrenadePool.pool.Push(gameObject);
        }
    }
}
