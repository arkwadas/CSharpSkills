using UnityEngine;

public class ColliderSynchronizer : MonoBehaviour
{
    private Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    private void Update()
    {
        _collider.transform.position = transform.position;
    }
}
