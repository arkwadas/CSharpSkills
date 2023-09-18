using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;
using RPG.Combat;

namespace MoreMountains.TopDownEngine
{
    public class UpHealth : Health
    {
        /*[SerializeField] UpdateHealth updateHealthScript;

        /*public new float CurrentHealth;
        public new float MaximumHealth;
        public new float InitialHealth;
        protected override void Start()
        {
            base.Start();
            updateHealthScript = GetComponent<UpdateHealth>();
        }

        protected override void Update()
        {
            base.Update();

            // update CurrentHealth and MaximumHealth values from UpdateHealth script
            CurrentHealth = updateHealthScript.GetHealth();
            MaximumHealth = updateHealthScript.MaxHealth();
            InitialHealth = updateHealthScript.GetInitialHealth();
        }

        // Przes³aniaj metodê Update() z klasy Health
        public float CurrentHealth
        {
            get { return GetCurrentHealth(); }
            set { }
        }*/
    }
}
