using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int keysRequired = 1;
    private bool isOpen = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isOpen)
        {
            GameEvents.instance.DoorInteracted(keysRequired, OpenDoor);
        }
    }
    private void OpenDoor()
    {
        if (!isOpen)
        {
            isOpen = true;
            animator.SetTrigger("Open");
            AudioManager.audioManager.PlayDoor();
            SceneManager.LoadSceneAsync("EndMenu");
        }
    }
}
