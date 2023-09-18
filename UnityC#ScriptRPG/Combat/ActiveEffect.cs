using MoreMountains.TopDownEngine;
using UnityEngine;

public class ActiveEffect : MonoBehaviour
{
    public GameObject particleEffect; // referencja do prefaba efektu cz¹steczkowego
    public float effectDuration = 1f; // czas trwania efektu cz¹steczkowego

    private void OnTriggerEnter(Collider other)
    {
        // SprawdŸ, czy kolizja wyst¹pi³a z obiektem, który ma skrypt Health
        Health health = other.gameObject.GetComponent<Health>();
        if (health != null)
        {
            // Utwórz efekt cz¹steczkowy wewn¹trz obiektu z kolizj¹
            GameObject effectInstance = Instantiate(particleEffect, other.transform.position, Quaternion.identity, other.transform);

            // Zniszcz efekt po okreœlonym czasie trwania
            Destroy(effectInstance, effectDuration);
        }
    }
}
