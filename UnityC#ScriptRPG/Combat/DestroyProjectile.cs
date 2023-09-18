using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyGameObject", 10.0f);
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
