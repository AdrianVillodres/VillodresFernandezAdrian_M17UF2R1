using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int keysRequired = 1;
    private bool isOpen = false;
    private Animator animator;
    private static int counter = 0;

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
            counter++;

            if(counter == 3)
            {
                StartCoroutine(Win());
            }
            else
            {
                StartCoroutine(Reload());
            }
        }

    }

    IEnumerator Win()
    {
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadSceneAsync("EndMenu");
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadSceneAsync("FirstLevelMain");
        Character.character.transform.position = Vector3.zero;
    }
}
