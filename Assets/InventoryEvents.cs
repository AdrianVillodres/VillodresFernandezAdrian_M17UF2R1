using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryEvents : MonoBehaviour
{
    private Inventory inventory;
    private void Start()
    {
        activateSword(0);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 1;
            SceneManager.UnloadSceneAsync("Inventory");
            PauseBehaviour.Pause = false;
        }
    }

    public void activateSword(int index)
    {
        inventory.weapons[index].SetActive(index == 0);
    }

    public void activateRifle(int index)
    {
        inventory.weapons[index].SetActive(index == 1);
    }

    public void activateGrenadeLauncher(int index)
    {
        inventory.weapons[index].SetActive(index == 2);
    }

    public void activateFlamethrower(int index)
    {
        inventory.weapons[index].SetActive(index == 3);
    }
}
