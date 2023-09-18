using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWithForce : MonoBehaviour
{
    public string targetTag = "Player";
    public Vector3 forceDirection = new Vector3(10.0f, 0.0f, 0.0f); // Kierunek si³y
    public float forceMagnitude = 100.0f; // Wielkoœæ si³y

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
            }
        }
    }
}
