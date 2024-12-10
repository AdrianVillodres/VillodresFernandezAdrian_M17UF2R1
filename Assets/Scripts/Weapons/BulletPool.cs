using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool pool;

    public GameObject Bullet;
    [SerializeField] private GameObject SpawnPoint;

    private Stack<GameObject> stack;

    void Start()
    {
        if (BulletPool.pool != null && BulletPool.pool != this)
        {
            Destroy(gameObject);
        }
        BulletPool.pool = this;


        stack = new Stack<GameObject>();
    }

    public void Push(GameObject obj)
    {
        obj.SetActive(false);
        stack.Push(obj);
    }

    public GameObject Pop()
    {
        if (stack.Count > 0)
        {
            GameObject obj = stack.Pop();
            obj.SetActive(true);
            obj.transform.position = SpawnPoint.transform.position;
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(Bullet, SpawnPoint.transform.position, Quaternion.identity);
            return obj;
        }
    }
}
