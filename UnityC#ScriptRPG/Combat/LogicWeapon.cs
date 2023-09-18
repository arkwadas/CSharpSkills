using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicWeapon : MonoBehaviour
{
    [SerializeField] private List<GameObject> weaponLogic;
    [SerializeField] private GameObject secendWeaponsLogic; 

    public void EnableWeapon()
    {
        foreach (GameObject obj in weaponLogic)
        {
            obj.SetActive(true);
            StartCoroutine(DisableWeaponsWithDelay(0.5f));
        }
    }

    public void DisableWeapon()
    {
        foreach (GameObject obj in weaponLogic)
        {
            obj.SetActive(false);
        }
    }
    public void EnableSecenWeapon()
    {
        secendWeaponsLogic.SetActive(true);
    }

    public void DisableSecendWeapon()
    {
        secendWeaponsLogic.SetActive(false);
    }
    private IEnumerator DisableWeaponsWithDelay(float delay)
    {
        foreach (GameObject obj in weaponLogic)
        {
            yield return new WaitForSeconds(delay);
            obj.SetActive(false);
        }
    }
}
