using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Velocidad de la bala
    public float lifetime = 2f; // Tiempo de vida de la bala

    private float lifeTimer;

    void OnEnable()
    {
        lifeTimer = lifetime;
    }

    void Update()
    {
        // Mover la bala
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Cuenta regresiva para devolver la bala al pool
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0)
        {
            BulletPool.pool.Push(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Lógica para colisión con enemigos (opcional)
            Destroy(other.gameObject);
        }

        // Devuelve la bala al pool tras la colisión
        BulletPool.pool.Push(gameObject);
    }
}
