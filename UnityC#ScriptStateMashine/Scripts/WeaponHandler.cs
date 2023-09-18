using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private GameObject weaponLogic;
    [SerializeField] private GameObject secendWeaponsLogic;

    public void EnableWeapon()
    {
        weaponLogic.SetActive(true);
    }

    public void DisableWeapon()
    {
        weaponLogic.SetActive(false);
    }
    public void EnableSecenWeapon()
    {
        secendWeaponsLogic.SetActive(true);
    }

    public void DisableSecendWeapon()
    {
        secendWeaponsLogic.SetActive(false);
    }
}
