using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPause : MonoBehaviour
{
    public GameObject entry;

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
;
    }

    private void OnDisable()
    {
        // Sprawdzamy, czy któryœ z obiektów jest nullem, i wykonujemy return, jeœli tak
        if (entry == null)
        {
            entry.SetActive(true);
            //Debug.LogError("Jeden z obiektów jest nullem w skrypcie EntryMenu!");
            return;
        }

         //W momencie wy³¹czenia skryptu, przywracamy wszystkie obiekty do aktywnoœci

    }
}