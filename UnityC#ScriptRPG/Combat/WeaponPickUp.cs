using RPG.Audio;
using RPG.Control;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class WeaponPickUp : MonoBehaviour
    {
        [SerializeField] WeaponConfig weapon = null;
        [SerializeField] string sound;
        [SerializeField] float respownTime = 5f;
        [SerializeField] float healthTORestore = 0;
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                Pickup(other.gameObject);
            }
        }

        private void Pickup(GameObject subject) // zmiany dikonnane dla cursora
        {
            if(weapon != null)
            {
                subject.GetComponent<Attack>().EquippWeapon(weapon);
            }
            //JAK DO TEJ PORY NIE INTERSUJE NAS ODZYSKIWANIE ZDROWIA, MOZE PÓNIEJ,ALE MAMY JU¯ GOTOWE STEMPACK
            //if(healthTORestore > 0)
            //{
             //   subject.GetComponent<Health>().Heal(healthTORestore);
            //}
            FindObjectOfType<AudioManager>().Play(sound);
            StartCoroutine(HideForSeconds(respownTime));
        }

        private IEnumerator HideForSeconds(float seconds)
        {
            ShowPickup(false);
            yield return new WaitForSeconds(seconds);
            ShowPickup(true);
        }

        

        private void ShowPickup(bool shouldShow)
        {
            GetComponent<Collider>().enabled = shouldShow;
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(shouldShow); //bycmoze da siê tutaj daæ transformacje przed graczem je¿eli przed graczem  jest pusty colidder?
            }
        }

        /*public bool HandleRaycast(PlayerControler callingController) //cursor podnoszenia broni
        {
            if (Input.GetMouseButtonDown(0))
            {
                Pickup(callingController.gameObject);
            }
            return true;
        }*/

        public CursorType GetCursorType()
        {
            return CursorType.Pickup;
        }
    }
}



