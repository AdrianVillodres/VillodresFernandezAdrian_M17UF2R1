using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weapons; 

    private void Start()
    {
        
        ActivateWeapon(0);
    }
    public void ActivateWeapon(int index)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i == index);
        }
    }
}
