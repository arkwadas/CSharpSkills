using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using RPG.Control;
using GameDevTV.Saving;
using MoreMountains.TopDownEngine;

namespace RPG.SceneManagement
{
    public class Portal : MonoBehaviour
    {
        enum DestinationIdentifer
        {
             A, B, C, D, E, F
        }

        [SerializeField] int sceneToLoad = 13;
        [SerializeField] Transform spawnPoint;
        [SerializeField] DestinationIdentifer destination;
        [SerializeField] float fadeOutTime = 1f;
        [SerializeField] float fadeInTime = 2f;
        [SerializeField] float fadeWaitTime = 0.5f;
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                StartCoroutine(Transition());
            }
            
        }
        public void OnClick()
        {
            StartCoroutine(Transition());
        }
        private IEnumerator Transition()
        {
            if(sceneToLoad < 0)
            {
                Debug.LogError("Scene to loadnot set.");
                yield break; 
            }

            
            DontDestroyOnLoad(gameObject);

            Fader fader = FindObjectOfType<Fader>();
            SavingWrapper wrapper = FindObjectOfType<SavingWrapper>();
            // Remove Cotroler
            Attack playerController = GameObject.FindWithTag("Player").GetComponent<Attack>();
            playerController.enabled = false;

            yield return fader.FadeOut(fadeOutTime);

            //wrapper.Save();
            wrapper.AutoSave();

            yield return SceneManager.LoadSceneAsync(sceneToLoad); //£adownie sceny asynchronicznej;
            // remove cotrol
           // Attack newPlayerController = GameObject.FindWithTag("Player").GetComponent<Attack>();
           // newPlayerController.enabled = false;

            // wrapper.Load();
            wrapper.LoadAutoSave();

            Portal otherPortal = GetOtherPortal();
            UpdatePlayer(otherPortal);

            //wrapper.Save();
            wrapper.AutoSave();

            yield return new WaitForSeconds(fadeWaitTime);
            fader.FadeIn(fadeInTime);


            // restore control
            //newPlayerController.enabled = true;
            Destroy(gameObject);
        }

        private void UpdatePlayer(Portal otherPortal)
        {
            GameObject player = GameObject.FindWithTag("Player");
            //player.GetComponent<NavMeshAgent>().Warp(otherPortal.spawnPoint.position);
            player.transform.position = otherPortal.spawnPoint.position;
            player.transform.rotation = otherPortal.spawnPoint.rotation;
            
        }

        private Portal GetOtherPortal()
        {
            foreach(Portal portal in FindObjectsOfType<Portal>())
            {
                if (portal == this) continue;
                if (portal.destination != destination) continue;


                return portal;
            }

            return null;
        }
    }
}


