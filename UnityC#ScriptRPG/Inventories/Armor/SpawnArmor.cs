using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArmor : MonoBehaviour
{
    public GameObject objectToSpawn; // Obiekt, kt�ry chcemy utworzy�
    public Transform spawnPosition; // Pozycja, na kt�rej chcemy utworzy� obiekt

    public void SpawnObjectAtPosition()
    {
        // Utw�rz nowy obiekt na pozycji "spawnPosition" z domy�ln� rotacj�
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition.position, Quaternion.identity);

        // Opcjonalnie mo�na przypisa� utworzony obiekt do innego obiektu w hierarchii
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
