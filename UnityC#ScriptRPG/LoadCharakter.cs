using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharakter : MonoBehaviour
{
    void Start()
    {
        GameObject dontDestroyObject = GameObject.FindGameObjectWithTag("Player");
        dontDestroyObject.transform.SetParent(transform);
    }
}
