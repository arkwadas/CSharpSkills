using MoreMountains.TopDownEngine;
using RPG.Shops;
using RPG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.UI.Shops;

public class ShopNPCGizmo : MonoBehaviour
{
    public float gizmoRadius = 1.0f;
    private bool playerInRange = false;
    private Health health;
    private Character character;
    public RPG.Shops.Shop shop;
    private CapsuleCollider npcCollider;
    private float initialColliderRadius; 
    public GameObject player = null;
    public GameObject shopUI = null;
    

    private void Awake()
    {
        npcCollider = GetComponent<CapsuleCollider>(); 
        initialColliderRadius = npcCollider.radius; 
        player = GameObject.FindWithTag("Player");
    }

    private void Start()
    {
        player = GameObject.Find("PlayerCharakter");
        shopUI = GameObject.Find("Player/UI Canvas/Shop UI Black background");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //playerInRange = true;
            health = other.GetComponent<Health>();
            //character = other.GetComponent<Character>();

           
            float distanceToPlayer = Vector3.Distance(other.transform.position, transform.position);
            if (distanceToPlayer < gizmoRadius)
            {
                npcCollider.radius = 4f;
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            health = null;
            npcCollider.radius = initialColliderRadius; // Dodane
            if (shopUI.activeSelf)
            {
                ShopUIDisable();
            }


        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
         {
            HandleRaycast(health);
         }
        bool result = HandleRaycast(health);
        if (character != null)
        {
            character.enabled = !result;
        }
    }
    
    public float RadiusUp()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if(distanceToPlayer < gizmoRadius)
        {
            npcCollider.radius = initialColliderRadius;
        }
        
        return initialColliderRadius;
    }

    public bool HandleRaycast(Health callingController)
    {
        if (callingController != null)
        {
            float distanceToPlayer = Vector3.Distance(callingController.transform.position, transform.position);
            if (distanceToPlayer < gizmoRadius && Input.GetKeyDown(KeyCode.E))
            {
                callingController.GetComponent<Shopper>().SetActiveShop(this.shop);
                ShopUIEnable();
                return true;
            }
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, gizmoRadius);
    }

    public void ShopUIEnable()
    {
        shopUI.SetActive(true);
    }

    public void ShopUIDisable()
    {
        shopUI.SetActive(false);
    }


public void SetNpcColliderRadius(float radius)
    {
        npcCollider.radius = radius;
    }

    public void ResetNpcColliderRadius()
    {
        npcCollider.radius = initialColliderRadius;
    }
}