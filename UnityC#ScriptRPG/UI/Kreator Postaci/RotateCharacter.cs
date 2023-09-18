using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCharacter : MonoBehaviour
{
    [SerializeField]
    private GameObject gameObjectToRotate;


    private float rotationSpeed = 90f;
    private float rotationSpeed2 = 2000f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObjectToRotate.transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObjectToRotate.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }

    public void RotateLeft()
    {
        gameObjectToRotate.transform.Rotate(0, -rotationSpeed2 * Time.deltaTime, 0);
    }

    public void RotateRight()
    {
        gameObjectToRotate.transform.Rotate(0, rotationSpeed2 * Time.deltaTime, 0);
    }
}
