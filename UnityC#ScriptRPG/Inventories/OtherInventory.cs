using GameDevTV.UI;
using RPG.Control;
using UnityEngine;

namespace GameDevTV.Inventories
{
    //[RequireComponent(typeof(Inventory))]
    public class OtherInventory : MonoBehaviour
    {
        /*private GameObject player;
        [SerializeField] float interactDistance = 4f;
        private float initialColliderRadius; // Dodane
        //public GameObject[] Disable;
        public CapsuleCollider coliderSize = null;
        public GameObject uI;

        private bool isPlayerInRange = false;

        private void Awake()
        {
            coliderSize = GetComponent<CapsuleCollider>(); // Dodane
            initialColliderRadius = coliderSize.radius; // Dodane
            player = GameObject.FindWithTag("Player");
        }

        private void Start()
        {
            uI = GameObject.Find("Hiding Panel");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == player)
            {
                isPlayerInRange = true;
                //pickupIcon.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == player)
            {
                isPlayerInRange = false;
                //pickupIcon.SetActive(false);
                uI.SetActive(false);
            }
        }

        private void Update()
        {
            if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
            {
                float distance = Vector3.Distance(player.transform.position, transform.position);
                if (distance <= interactDistance)
                {
                    FindObjectOfType<ShowHideUI>().ShowOtherInventory(gameObject);
                }
            }
        }
        public void SetNpcColliderRadius(float radius)
        {
            coliderSize.radius = radius;
        }

        public void ResetNpcColliderRadius()
        {
            coliderSize.radius = initialColliderRadius;
        }*/
    }
}
