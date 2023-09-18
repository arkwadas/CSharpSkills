using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.SceneManagement;
using GameDevTV.Saving;

namespace RPG.Outfil
{
    public class OutfilChanger : MonoBehaviour, ISaveable
    {
        [Header("Zmiana gander")]
        public GameObject[] gander;
        private int currentGander;
        SavingWrapper save;

        [SerializeField] GameObject man = null;
        [SerializeField] GameObject manParts = null;
        [SerializeField] GameObject women = null;
        [SerializeField] GameObject womenParts = null;
        [SerializeField] GameObject panel = null;
        [SerializeField] GameObject panel1 = null;
        [SerializeField] GameObject lastObject = null;
        [SerializeField] GameObject uszyMezczyzna = null;
        [SerializeField] GameObject opisCzlowiek = null;

        /*private void Update()
        {
            for (int i = 0; i < gander.Length; i++)
            {
                if (i == currentGander)
                {
                    gander[i].SetActive(true);
                }
                else
                {
                    gander[i].SetActive(false);
                }
            }

        }*/

        public object CaptureState()
        {
            return currentGander;
            /*Dictionary<string, object> data = new Dictionary<string, object>();
            data["P³eæ"] = gander;
            data["Mê¿czyzna"] = man;
            data["Kobieta"] = women;
            data["Czêœci Mê¿czyzna"] = manParts;
            data["Czêœci Kobieta"] = womenParts;
            data["Uszy"] = uszyMezczyzna;
 

                
        return data;*/

        }

        public void RestoreState(object state)
        {
            Debug.Log("RestoreState");

            currentGander = (int)state;
            /*Dictionary<string, object> data = (Dictionary<string, object>)state;
            int gd = (int)data["P³eæ"];*/


        }

        public void SwitchNext()
        {
            if (currentGander == gander.Length - 1)
            { currentGander = 0; }
            else
            { currentGander++; }
        }
        public void SwitchBack()
        {
            if (currentGander == 0)
            {
                currentGander = gander.Length - 1;
            }
            else
            {
                currentGander--;
            }

        }

        public void WhenButtonClickedMan()
        {
            if (man.activeInHierarchy == false)
            {
                man.SetActive(true);
                women.SetActive(false);
            }

            if (manParts.activeInHierarchy == false)
            {
                manParts.SetActive(true);
                womenParts.SetActive(false);
            }
        }
        public void WhenButtonClickedWomen()
        {
            if (women.activeInHierarchy == false)
            {
                women.SetActive(true);
                man.SetActive(false);
            }
            else
            {
                return;
            }

            if (womenParts.activeInHierarchy == false)
            {
                womenParts.SetActive(true);
                manParts.SetActive(false);
            }
            else
            { return; }


        }
        public void WhenButtonClickedtest()
        {
            if (women.activeInHierarchy == false)
            {
                women.SetActive(true);
                man.SetActive(false);
            }
            else
            {
                return;
            }

            if (womenParts.activeInHierarchy == false)
            {
                womenParts.SetActive(true);
                manParts.SetActive(false);
            }
            else
            { return; }


        }


        public void WhenButtonClickedDisablePanel()
        {
            if (panel.activeInHierarchy == true)
            {
                panel.SetActive(false);
            }
            else
            {
                panel.SetActive(true);
                panel1.SetActive(false);
            }
        }

        public void WhenButtonClickedElf()
        {
            if (panel.activeInHierarchy == false)
            {
                panel.SetActive(true);
                panel1.SetActive(true);
                lastObject.SetActive(false);
            }
            else
            {
                return;
            }
        }

        public void WhenButtonClickedCzlowiek()
        {
            if (panel.activeInHierarchy == true)
            {
                panel.SetActive(false);
                panel1.SetActive(false);
                lastObject.SetActive(false);
                uszyMezczyzna.SetActive(false);
                opisCzlowiek.SetActive(true);
            }
            else
            {
                return;
            }
        }

        public void WhenClickedBackToMainMenu()
        {
            if (panel.activeInHierarchy == true)
            {
                panel.SetActive(false);
                panel1.SetActive(false);
                lastObject.SetActive(true);
            }
            else
            {
                return;
            }
        }
        public void Activity()
        {
            if (panel.activeInHierarchy == false)
            {
                panel.SetActive(true);

            }
            else
            {
                return;
            }
        }



    }
}