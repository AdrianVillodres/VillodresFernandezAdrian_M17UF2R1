using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryEvents : MonoBehaviour
{
    private Inventory inventory;
    private ShopManager shopManager;

    private void Start()
    {
        shopManager = FindObjectOfType<ShopManager>();
        if (shopManager == null)
        {
            Debug.LogError("No se encontró ShopManager en la escena.");
        }

        activateSword(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 1;
            SceneManager.UnloadSceneAsync("Inventory");
            InputManager.Pause = false;
        }
    }

    public void activateSword(int index)
    {
        inventory.weapons[index].SetActive(index == 0);
    }

    public void activateRifle(int index)
    {
        if (shopManager != null && shopManager.riflepurchased)
        {
            inventory.weapons[index].SetActive(index == 1);
        }
        else
        {
            Debug.Log("El rifle no ha sido comprado aún.");
        }
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
