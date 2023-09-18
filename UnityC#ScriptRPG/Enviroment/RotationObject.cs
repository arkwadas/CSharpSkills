using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour
{

    [SerializeField] float rotationSpeed;

    [SerializeField] Vector3 rotationDirection = new Vector3();


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * rotationDirection * Time.deltaTime); 
    }
}
