using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charakters : MonoBehaviour
{
    public static Charakters instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
