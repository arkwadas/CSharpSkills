using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController cotroller;

    private Collider[] allColiders;
    private Rigidbody[] allRigidbodies;
    private void Start()
    {
        allColiders = GetComponentsInChildren<Collider>(true);
        allRigidbodies = GetComponentsInChildren<Rigidbody>(true);

        ToggleRagdoll(false); // mamy wy³¹czony ragdoll na samym poczatku
    }

    public void ToggleRagdoll(bool isRagdoll)
    {
        foreach(Collider collider in allColiders)
        {
            if (collider.gameObject.CompareTag("Ragdoll"))
            {
                collider.enabled = isRagdoll;
            }
        }
        foreach (Rigidbody rigidbody in allRigidbodies)
        {
            if (rigidbody.gameObject.CompareTag("Ragdoll"))
            {
                rigidbody.isKinematic = !isRagdoll;
                rigidbody.useGravity = isRagdoll;
            }
        }

        cotroller.enabled = !isRagdoll; // wy³acz kontroler gdy uzyjemy ragdoll
        animator.enabled = !isRagdoll; // wy;acz animator gdy uzywamy ragdoll
    }

}
