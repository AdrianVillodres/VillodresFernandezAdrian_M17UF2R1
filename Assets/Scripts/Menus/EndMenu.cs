using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.Unicode;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartButton()
    {
        Character.character = null;
        Destroy(GameObject.Find("MainCharacter"));
        Destroy(GameObject.Find("AudioManager"));
        Destroy(GameObject.Find("GameEventsManager"));
        Door.counter = 0;
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        InputManager.Pause = false;
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
