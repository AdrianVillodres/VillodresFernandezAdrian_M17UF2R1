using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 45f; // Velocidad de rotación
    [SerializeField] private Transform rotateAround; // Punto alrededor del cual rota el arma
    public Transform player; // Referencia al jugador

    void Start()
    {

    }

    void Update()
    {
        // Obtener la posición del ratón en el mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Asegurarnos de que la posición Z esté igual a la del jugador (en 2D el Z debería ser constante)
        mousePosition.z = player.position.z;

        // Calcular la dirección desde el arma hacia el ratón
        Vector3 direction = mousePosition - rotateAround.position;

        // Calcular el ángulo entre la dirección del arma y la dirección hacia el ratón
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotar el arma hacia el puntero del ratón
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
