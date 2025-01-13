using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
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
