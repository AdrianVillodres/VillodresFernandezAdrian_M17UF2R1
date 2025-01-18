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
        inventory = Character.character.GetComponent<Inventory>();
        if (shopManager == null)
        {
            Debug.LogError("No se encontró ShopManager en la escena.");
        }
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

    public void ActivateSword(int index)
    {
        DesactivateWeapon(inventory.currentWeaponIndex);
        inventory.weapons[index].SetActive(index == 0);
        inventory.currentWeaponIndex = index;
    }

    public void ActivateRifle(int index)
    {
        if (shopManager != null && shopManager.riflepurchased)
        {
            DesactivateWeapon(inventory.currentWeaponIndex);
            inventory.weapons[index].SetActive(index == 1);
            inventory.currentWeaponIndex = index;
        }
        else
        {
            Debug.Log("El rifle no ha sido comprado aún.");
        }
    }

    public void ActivateGrenadeLauncher(int index)
    {
        if (shopManager != null && shopManager.grenadepurchased)
        {
            DesactivateWeapon(inventory.currentWeaponIndex);
            inventory.weapons[index].SetActive(index == 2);
            inventory.currentWeaponIndex = index;
        }
        else
        {
            Debug.Log("El lanzagranadas no ha sido comprado aún.");
        }
    }

    public void ActivateFlamethrower(int index)
    {
        if (shopManager != null && shopManager.flamepurchased)
        {
            DesactivateWeapon(inventory.currentWeaponIndex);
            inventory.weapons[index].SetActive(index == 3);
            inventory.currentWeaponIndex = index;
        }
        else
        {
            Debug.Log("El lanzallamas no ha sido comprado aún.");
        }
    }

    public void DesactivateWeapon(int index)
    {
        inventory.weapons[index].SetActive(false);
    }
}
