using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.Collections.Unicode;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

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
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("PauseMenu");
        PauseBehaviour.Pause = false;
    }

    public void RestartButton()
    {
        Character.character = null;
        Destroy(GameObject.Find("MainCharacter"));
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
