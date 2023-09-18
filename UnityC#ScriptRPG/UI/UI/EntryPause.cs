using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPause : MonoBehaviour
{
    public GameObject entry;

    private void OnEnable()
    {
        // Sprawdzamy, czy kt�ry� z obiekt�w jest nullem, i wykonujemy return, je�li tak
        //if (entry == null || off1 == null || off2 == null || off3 == null)
        //{
            //Debug.LogError("Jeden z obiekt�w jest nullem w skrypcie EntryMenu!");
           // return;
       // }

        // Wy��czamy pozosta�e obiekty, tylko entry ma by� aktywny
        entry.SetActive(true);
;
    }

    private void OnDisable()
    {
        // Sprawdzamy, czy kt�ry� z obiekt�w jest nullem, i wykonujemy return, je�li tak
        if (entry == null)
        {
            entry.SetActive(true);
            //Debug.LogError("Jeden z obiekt�w jest nullem w skrypcie EntryMenu!");
            return;
        }

         //W momencie wy��czenia skryptu, przywracamy wszystkie obiekty do aktywno�ci

    }
}