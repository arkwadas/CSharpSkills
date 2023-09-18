using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArmor : MonoBehaviour
{
    public GameObject objectToSpawn; // Obiekt, który chcemy utworzyæ
    public Transform spawnPosition; // Pozycja, na której chcemy utworzyæ obiekt

    public void SpawnObjectAtPosition()
    {
        // Utwórz nowy obiekt na pozycji "spawnPosition" z domyœln¹ rotacj¹
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition.position, Quaternion.identity);

        // Opcjonalnie mo¿na przypisaæ utworzony obiekt do innego obiektu w hierarchii
        spawnedObject.transform.SetParent(spawnPosition);
    }
    public ActivateHelmet Spawn(Transform transform)
    {
 
        ActivateHelmet helmet = null;

        if (helmet != null)
        {
            SpawnObjectAtPosition();
        }

            return helmet;

        }


    }
