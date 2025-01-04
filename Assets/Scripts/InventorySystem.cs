using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public GameObject[] weaponSlots; // Array de ranuras de inventario (botones o imágenes)
    public Sprite[] weaponIcons;     // Íconos de las armas disponibles
    public GameObject[] weapons;     // Prefabs de las armas
    public Transform weaponHolder;   // Transform donde se equipará el arma

    private int currentWeaponIndex = 0;

    void Start()
    {
        UpdateInventoryUI();
    }

    public void EquipWeapon(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= weapons.Length)
            return;

        // Destruir arma actual
        foreach (Transform child in weaponHolder)
        {
            Destroy(child.gameObject);
        }

        // Instanciar nueva arma
        GameObject newWeapon = Instantiate(weapons[slotIndex], weaponHolder);
        currentWeaponIndex = slotIndex;

        Debug.Log($"Arma equipada: {weapons[slotIndex].name}");
    }

    public void UpdateInventoryUI()
    {
        for (int i = 0; i < weaponSlots.Length; i++)
        {
            // Actualizar los íconos de las ranuras
            if (i < weaponIcons.Length)
                weaponSlots[i].GetComponent<Image>().sprite = weaponIcons[i];
            else
                weaponSlots[i].SetActive(false); // Desactivar ranuras vacías
        }
    }
}
