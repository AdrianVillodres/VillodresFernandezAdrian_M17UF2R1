using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    [SerializeField] private Transform rotateAround;
    [SerializeField] private float distanceFromPlayer = 1.5f;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = rotateAround.position.z;
        Vector3 direction = (mousePosition - rotateAround.position).normalized;
        transform.position = rotateAround.position + direction * distanceFromPlayer;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
