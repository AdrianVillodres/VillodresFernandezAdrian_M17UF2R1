using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToInventoryBehaviour : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 0;
            Pause = true;
            SceneManager.LoadScene("Inventory", LoadSceneMode.Additive);
        }
    }
}
