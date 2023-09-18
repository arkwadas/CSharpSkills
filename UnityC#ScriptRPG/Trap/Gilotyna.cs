using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gilotyna : MonoBehaviour
{
    // Define the speed of the pendulum
    float speed = 0.05f;

    // Define the angle range of the pendulum
    float angleRange = 90f;

    // Define the starting angle of the pendulum
    float currentAngle = 0f;

    // Define the direction of the pendulum (1 for right, -1 for left)
    int direction = 1;

    // Define a boolean to control if the pendulum is activated or not
    public bool isActivated = false;

    // Define a variable to control the deceleration of the pendulum
    public float deceleration = 0.05f;

    // Update the pendulum position in each frame
    void Update()
    {
        if (isActivated)
        {
            currentAngle += speed * direction;
            if (currentAngle >= angleRange)
            {
                direction = -1;
            }
            else if (currentAngle <= -angleRange)
            {
                direction = 1;
            }
            transform.rotation = Quaternion.Euler(0, currentAngle, 0);

            // Decrease the speed of the pendulum over time
            speed -= deceleration * Time.deltaTime;
        }
    }

    // Trigger to activate the pendulum when the player enters the trap
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isActivated = true;
        }
    }

    // Trigger to deactivate the pendulum when the player exits the trap
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isActivated = false;
        }
    }

}
