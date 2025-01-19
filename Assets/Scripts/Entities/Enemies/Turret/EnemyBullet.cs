using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;
    private float lifeTimer;
    private EnemyBulletPool pool;

    private void Start()
    {
        pool = GameObject.Find("Shoots").GetComponent<EnemyBulletPool>();
    }

    void OnEnable()
    {
        lifeTimer = lifetime;
    }

    private void OnDisable()
    {
        pool.Push(gameObject);
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0)
        {
            pool.Push(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IHurteable>(out var player) && collision.gameObject.CompareTag("Player"))
        {
            player.Hurt(1);
        }
        gameObject.SetActive(false);
    }
}
