using UnityEngine;

public class Door : MonoBehaviour
{
    public int keysRequired = 2; // Número de llaves necesarias para abrir la puerta
    private bool isOpen = false; // Estado de la puerta
    private Animator animator; // Referencia al componente Animator

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Falta el componente Animator en la puerta.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isOpen)
        {
            GameEvents.instance.DoorInteracted(keysRequired, OpenDoor); // Notificar evento
        }
    }
    private void OpenDoor()
    {
        if (!isOpen)
        {
            Debug.Log("Puerta abierta.");
            isOpen = true;

            // Activar la animación de abrir puerta
            if (animator != null)
            {
                animator.SetBool("Open", true);
            }
        }
    }
}
