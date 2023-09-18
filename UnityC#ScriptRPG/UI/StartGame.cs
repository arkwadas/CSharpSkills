using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RPG.SceneManagement;
using MoreMountains.Tools;
using System;
using UnityEditor;
using MoreMountains.TopDownEngine;

namespace RPG.Core
{
    public class StartGame : MonoBehaviour

    {
        [SerializeField] int sceneToLoad = -1;
        public GameObject character;
        
        

        public void PlayGame()
        {
            GameObject character = GameObject.Find("PlayerCharakter");

            // Pobierz komponent Character Orientation 3D z obiektu
            CharacterOrientation3D characterOrientation = character.GetComponent<CharacterOrientation3D>();

            // W³¹cz skrypt
            characterOrientation.enabled = true;
            //SavingWrapper wrapper = FindObjectOfType<SavingWrapper>();
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            



        }
        public void SaveClick()
        {
            SavingWrapper wrapper = FindObjectOfType<SavingWrapper>();
            wrapper.Save();
        }

        private IEnumerator Transition()
        {
            if (sceneToLoad < 0)
            {
                Debug.LogError("Scene to loadnot set.");
                yield break;
            }


            DontDestroyOnLoad(gameObject);

            SavingWrapper wrapper = FindObjectOfType<SavingWrapper>();

            wrapper.Save();

            yield return SceneManager.LoadSceneAsync(sceneToLoad); //£adownie sceny asynchronicznej;
                                                                   // remove cotrol


            wrapper.Load();
        }

        public void ActivePortal()
        {
            character.SetActive(true);
        }

    }

    


}
