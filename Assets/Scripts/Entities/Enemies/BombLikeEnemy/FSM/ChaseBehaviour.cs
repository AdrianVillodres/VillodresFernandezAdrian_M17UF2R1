using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviour : MonoBehaviour
{
    public float Speed;

    public void Chase(Transform target, Transform self)
    {
        self.position = Vector3.MoveTowards(self.position, target.position, Speed * Time.deltaTime);
    }

    public void Run(Transform target, Transform self)
    {
        Vector3 directionAway = (self.position - target.position).normalized;
        self.position += directionAway * Speed * Time.deltaTime;
    }

    public void StopChasing()
    {
    }
}
