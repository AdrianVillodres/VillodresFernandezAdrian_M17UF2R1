using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBehaviour : MonoBehaviour
{
    public static bool Pause;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Pause)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            Pause = true;
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
        }
    }
}
