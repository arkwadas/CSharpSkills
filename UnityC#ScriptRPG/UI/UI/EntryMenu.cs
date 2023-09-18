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
        // Sprawdzamy, czy kt�ry� z obiekt�w jest nullem, i wykonujemy return, je�li tak
        //if (entry == null || off1 == null || off2 == null || off3 == null)
        //{
            //Debug.LogError("Jeden z obiekt�w jest nullem w skrypcie EntryMenu!");
           // return;
       // }

        // Wy��czamy pozosta�e obiekty, tylko entry ma by� aktywny
        entry.SetActive(true);
        off1.SetActive(false);
        off2.SetActive(false);
        off3.SetActive(false);
    }

    private void OnDisable()
    {
        // Sprawdzamy, czy kt�ry� z obiekt�w jest nullem, i wykonujemy return, je�li tak
        if (entry == null || off1 == null || off2 == null || off3 == null)
        {
            //Debug.LogError("Jeden z obiekt�w jest nullem w skrypcie EntryMenu!");
            return;
        }

         //W momencie wy��czenia skryptu, przywracamy wszystkie obiekty do aktywno�ci
        entry.SetActive(false);
        off1.SetActive(false);
        off2.SetActive(false);
        off3.SetActive(false);
    }
}