using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitching : MonoBehaviour
{
    [Header("Lista de Armas")]
    public List<GameObject> weapons;

    private int currentWeaponIndex = 0;
    private Inputs playerInputs;
    public BRifle brifle;

    void Awake()
    {
        playerInputs = new Inputs();

        playerInputs.Weapon.Change.performed += OnChange;
    }

    void OnEnable()
    {
        playerInputs.Enable();
    }

    void OnDisable()
    {
        playerInputs.Disable();
    }

    void Start()
    {
        ActivateWeapon(currentWeaponIndex);
    }
    private void OnChange(InputAction.CallbackContext context)
    {
        string key = context.control.name;

        switch (key)
        {
            case "1":
                SwitchWeapon(0);
                break;
            case "2":
                if(brifle.purchased == true)
                {
                    SwitchWeapon(1);
                    Debug.Log("entro y cambio");
                }
                break;
            case "3":
                SwitchWeapon(2);
                break;
            case "4":
                SwitchWeapon(3);
                break;
        }
    }

    private void SwitchWeapon(int weaponIndex)
    {
        if (weaponIndex == currentWeaponIndex || weaponIndex < 0 || weaponIndex >= weapons.Count) return;

        ActivateWeapon(weaponIndex);
        currentWeaponIndex = weaponIndex;
    }

    private void ActivateWeapon(int index)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(i == index);
        }
    }
}
