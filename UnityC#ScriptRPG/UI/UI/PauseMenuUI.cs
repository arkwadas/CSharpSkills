using MoreMountains.TopDownEngine;
using RPG.Control;
using RPG.SceneManagement;
using UnityEngine;

namespace RPG.UI
{
    public class PauseMenuUI : MonoBehaviour
    {

        Attack playerController;
        [SerializeField] GameObject wylaczGdyAktywnyIUruchom = null;
        public GameObject[] obiektNull = null;


        private void Start() {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>();
            wylaczGdyAktywnyIUruchom.SetActive(true);
        }

        private void OnEnable()
        {
            wylaczGdyAktywnyIUruchom.SetActive(false);
            if (playerController == null) return;
            
            playerController.enabled = false;
            if(wylaczGdyAktywnyIUruchom != null)
            {
                wylaczGdyAktywnyIUruchom.SetActive(false);
            }
            wylaczGdyAktywnyIUruchom.SetActive(false);
            Time.timeScale = 0;

        }

        private void OnDisable()
        {
            
            // Sprawdzamy, czy wszystkie obiekty w liœcie s¹ wy³¹czone
            bool allObjectsInactive = true;
            foreach (GameObject obj in obiektNull)
            {
                if (obj.activeSelf)
                {
                    allObjectsInactive = false;
                    break;
                }
            }

            // Jeœli wszystkie obiekty s¹ wy³¹czone, wykonujemy jak¹œ akcjê
            if (allObjectsInactive)
            {
                Time.timeScale = 1;
                wylaczGdyAktywnyIUruchom.SetActive(true);
                if (playerController == null) return;

                playerController.enabled = true;
            }
            Time.timeScale = 1;



        }

        public void Save()
        {
            SavingWrapper savingWrapper = FindObjectOfType<SavingWrapper>();
            savingWrapper.Save();
        }

        public void SaveAndQuit()
        {
            SavingWrapper savingWrapper = FindObjectOfType<SavingWrapper>();
            savingWrapper.Save();
            savingWrapper.OpenMenu();
        }
    }
}