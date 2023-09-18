using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryMenu : MonoBehaviour
{
    public GameObject entry;
    public GameObject off1;
    public GameObject off2;
    public GameObject off3;

    private void OnEnable()
    {
        // Sprawdzamy, czy któryœ z obiektów jest nullem, i wykonujemy return, jeœli tak
        //if (entry == null || off1 == null || off2 == null || off3 == null)
        //{
            //Debug.LogError("Jeden z obiektów jest nullem w skrypcie EntryMenu!");
           // return;
       // }

        // Wy³¹czamy pozosta³e obiekty, tylko entry ma byæ aktywny
        entry.SetActive(true);
        off1.SetActive(false);
        off2.SetActive(false);
        off3.SetActive(false);
    }

    private void OnDisable()
    {
        // Sprawdzamy, czy któryœ z obiektów jest nullem, i wykonujemy return, jeœli tak
        if (entry == null || off1 == null || off2 == null || off3 == null)
        {
            //Debug.LogError("Jeden z obiektów jest nullem w skrypcie EntryMenu!");
            return;
        }

         //W momencie wy³¹czenia skryptu, przywracamy wszystkie obiekty do aktywnoœci
        entry.SetActive(false);
        off1.SetActive(false);
        off2.SetActive(false);
        off3.SetActive(false);
    }
}