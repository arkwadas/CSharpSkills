using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace RPG.Combat
{
    public class BarHealth : MonoBehaviour
    {
        public Image healthBar = null;
        [SerializeField] TextMeshProUGUI healthText = null;

        [SerializeField] UpdateHealth healthUpdate = null;

        void Update()
        {
            HealthBar();
            //UpdateMMCurrentHealth();
        }

       

        private void HealthBar()
        {
            healthBar.fillAmount = healthUpdate.GetHealth() / healthUpdate.MaxHealth();
            healthText.text = Mathf.FloorToInt(healthUpdate.GetHealth()).ToString();
        }
    }
}

