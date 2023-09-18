using MoreMountains.TopDownEngine;
using UnityEngine;

public class ActiveEffect : MonoBehaviour
{
    public GameObject particleEffect; // referencja do prefaba efektu cz�steczkowego
    public float effectDuration = 1f; // czas trwania efektu cz�steczkowego

    private void OnTriggerEnter(Collider other)
    {
        // Sprawd�, czy kolizja wyst�pi�a z obiektem, kt�ry ma skrypt Health
        Health health = other.gameObject.GetComponent<Health>();
        if (health != null)
        {
            // Utw�rz efekt cz�steczkowy wewn�trz obiektu z kolizj�
            GameObject effectInstance = Instantiate(particleEffect, other.transform.position, Quaternion.identity, other.transform);

            // Zniszcz efekt po okre�lonym czasie trwania
            Destroy(effectInstance, effectDuration);
        }
    }
}
