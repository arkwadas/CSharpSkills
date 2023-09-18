using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outfill
    {
    public class ActiveOutfill : MonoBehaviour
    {
        public GameObject BrakEkwipunku;
        public GameObject AktywujEkwipunek;

        private void Awake()
        {
            //ActivateOutfill();
        }
        public void ActivateOutfill()
        {
            // Dezaktywuj obiekt, jeœli jest przypisany.
            if (BrakEkwipunku != null)
            {
                BrakEkwipunku.SetActive(false);
            }

            // Aktywuj obiekt, jeœli jest przypisany.
            if (AktywujEkwipunek != null)
            {
                AktywujEkwipunek.SetActive(true);
            }
        }
    }
}
