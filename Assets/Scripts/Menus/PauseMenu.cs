using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.Collections.Unicode;

public class PauseMenu : MonoBehaviour
{
    Character character;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeButton();
        }
    }

    public void ResumeButton()
    {
        SceneManager.UnloadSceneAsync("PauseMenu");
        Time.timeScale = 1;
        InputManager.Pause = false;
    }

    public void RestartButton()
    {
        Character.character = null;
        Destroy(GameObject.Find("MainCharacter"));
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        InputManager.Pause = false;
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
