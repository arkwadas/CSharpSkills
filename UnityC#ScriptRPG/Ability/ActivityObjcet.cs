using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityObjcet : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;
    [SerializeField] private float activationDelay = 0f;
    [SerializeField] private float deactivateDelay = 1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(ActivateWithDelay());
        }
    }

    IEnumerator ActivateWithDelay()
    {
        yield return new WaitForSeconds(activationDelay);
        objectToActivate.SetActive(true);
        StartCoroutine(DeactivateWithDelay());
    }

    IEnumerator DeactivateWithDelay()
    {
        yield return new WaitForSeconds(deactivateDelay);
        objectToActivate.SetActive(false);
    }
}
