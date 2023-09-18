using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGizmoArea : MonoBehaviour
{
    [SerializeField] private ShopNPCGizmo shopNPCGizmo;
    public GameObject ImageShop = null;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            ShopImageEnable();
            shopNPCGizmo.SetNpcColliderRadius(4f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShopImageDisable();
            shopNPCGizmo.ResetNpcColliderRadius();
        }
    }

    public void ShopImageEnable()
    {
        ImageShop.SetActive(true);
    }

    public void ShopImageDisable()
    {
        ImageShop.SetActive(false);
    }
}
