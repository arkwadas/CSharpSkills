using RPG.Customization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHelmet : MonoBehaviour
{
    [SerializeField] int newId;
    private void Update()
    {
        SetManArmorPancerzId();
    }
    private void SetManArmorPancerzId()
    {
        CharacterCustomization characterCustomization = FindObjectOfType<CharacterCustomization>();
        characterCustomization.SetManArmorPancerzId(newId);
    }


}
