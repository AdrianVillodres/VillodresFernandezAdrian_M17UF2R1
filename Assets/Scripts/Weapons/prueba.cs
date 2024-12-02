using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 45f; // Velocidad de rotaci�n
    [SerializeField] private Transform rotateAround; // Punto alrededor del cual rota el arma
    public Transform player; // Referencia al jugador

    void Start()
    {

    }

    void Update()
    {
        // Obtener la posici�n del rat�n en el mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Asegurarnos de que la posici�n Z est� igual a la del jugador (en 2D el Z deber�a ser constante)
        mousePosition.z = player.position.z;

        // Calcular la direcci�n desde el arma hacia el rat�n
        Vector3 direction = mousePosition - rotateAround.position;

        // Calcular el �ngulo entre la direcci�n del arma y la direcci�n hacia el rat�n
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotar el arma hacia el puntero del rat�n
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
