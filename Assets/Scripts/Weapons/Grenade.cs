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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }

        GrenadePool.pool.Push(gameObject);
    }
}
