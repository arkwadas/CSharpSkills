using GameDevTV.Inventories;
using RPG.Customization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorsoModelChanger : MonoBehaviour
{
    //CharacterCustomization helmetCharacter;
    public List<GameObject> torsoModels;
    Equipment equipment;
    CharacterCustomization characterCustomization;

    private void Awake()
    {
        GetAllTorsoModels();

        equipment = GetComponent<Equipment>();
        if (equipment)
        {
            // UpdateHelmet();
        }

    }



    private void GetAllTorsoModels()
    {
        int torse = transform.childCount;

        for (int i = 0; i < torse; i++)
        {
            torsoModels.Add(transform.GetChild(i).gameObject);
        }
    }

    public void UnEquipAllTorsotModels()
    {
        foreach (GameObject torseModel in torsoModels)
        {
            torseModel.SetActive(false);
        }
    }

    public void EquipTorsoModelByName(string torseName)
    {
        for (int i = 0; i < torsoModels.Count; i++)
        {
            if (torsoModels[i].name == torseName)
            {
                torsoModels[i].SetActive(true);
            }
        }
    }
}
