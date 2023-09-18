using MoreMountains.TopDownEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayBarier : MonoBehaviour
{


    public Transform target;  // referencja do obiektu, kt�rego pozycja ma by� skopiowana
    public Collider objectCollider;  // referencja do Collidera tego obiektu

    // Metoda wywo�ywana na starcie
    private void Start()
    {
        // Pobierz Collider tego obiektu
        objectCollider = GetComponent<Collider>();
    }

    // Metoda wywo�ywana na ka�dej klatce animacji
    private void Update()
    {
        // Ustaw pozycj� tego obiektu na pozycji celu
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
            if (other.CompareTag("Projectile")) // zmie� tag na ten, kt�rym oznaczysz pociski gracza
            {
                Destroy(other.gameObject); //niszczymy pocisk gracza
            }
        }
    }
}
