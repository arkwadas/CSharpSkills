using MoreMountains.TopDownEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayBarier : MonoBehaviour
{


    public Transform target;  // referencja do obiektu, którego pozycja ma byæ skopiowana
    public Collider objectCollider;  // referencja do Collidera tego obiektu

    // Metoda wywo³ywana na starcie
    private void Start()
    {
        // Pobierz Collider tego obiektu
        objectCollider = GetComponent<Collider>();
    }

    // Metoda wywo³ywana na ka¿dej klatce animacji
    private void Update()
    {
        // Ustaw pozycjê tego obiektu na pozycji celu
        transform.position = target.position;
        if (!objectCollider.enabled)
        {
            objectCollider.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Projectile")) // zmieñ tag na ten, którym oznaczysz pociski gracza
            {
                Destroy(other.gameObject); //niszczymy pocisk gracza
            }
        }
    }
}
