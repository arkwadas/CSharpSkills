using System.Collections;
using System.Collections.Generic;
using RPG.Control;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Dialogue
{
    public class AIConversant : MonoBehaviour//, IRaycastable
    {
        [SerializeField] private InteractUI callingController;
        [SerializeField] Dialogue dialogue = null;
        [SerializeField] string conversantName;
        [SerializeField] GameObject conversantIcon = null;
        [SerializeField] Image conversatImage = null;

        private bool isPlayerInRange = false;

        public CursorType GetCursorType()
        {
            return CursorType.Dialogue;
        }

        //!!!!!!!!!!!!!!!!!! to dodaæ ¿eby po œmierci z nimi nie gadaæ gdybym zdecydowa³ siê na te rozwiazanie

        /*public bool HandleRaycast(InteractUI callingController)
        {
            if (dialogue == null)
            {
                return false;
            }

            Health health = GetComponent<Health>();
            if (health && health.IsDead()) return false;

            if (Input.GetMouseButtonDown(0))
            {
                callingController.GetComponent<PlayerConversant>().StartDialogue(this, dialogue);
            }
            return true;
        }*/

        private void Update()
        {
            if (isPlayerInRange)
            {
                conversantIcon.SetActive(true); // Aktywujemy obiekt, gdy gracz jest w zasiêgu

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (dialogue != null)
                    {
                        callingController.GetComponent<PlayerConversant>().StartDialogue(this, dialogue);
                    }
                }
            }
            else
            {
                conversantIcon.SetActive(false); // Dezaktywujemy obiekt, gdy gracz opuœci zasiêg
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerInRange = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerInRange = false;
            }
        }


        public string GetName()
        {
            return conversantName;
        }

        public Image GetImage()
        {
            return conversatImage;
        }
    }
}