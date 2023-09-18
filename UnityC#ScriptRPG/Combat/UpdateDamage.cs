using System.Collections;
using System.Collections.Generic;
using GameDevTV.Utils;
using UnityEngine;
using RPG.Stats;
using MoreMountains.TopDownEngine;
using MoreMountains.Tools;
using UnityEngine.Events;
using RPG.Core;
using GameDevTV.Saving;
using RPG.Control;

namespace RPG.Combat
{
    public class UpdateDamage : MonoBehaviour//, ISaveable
    {
        public GameObject playerCharacter = null;
        public GameObject targetObject = null;
        private GameObject PlayertargetObject;
        private BaseStats playerBaseStats;

        public DamageOnTouch LogicWeponOrEnemy = null;
        BaseStats targetBaseStats = null;
        
        //LazyValue<float> defence;
        LazyValue<float> minDamage;
        LazyValue<float> maxDamage;


        private void Start()
        {
            ToSameDamage();
            FindPlayerDefense();
        }

        private void FindPlayerDefense()
        {
            // Pobierz obiekt gracza na podstawie tagu
            PlayertargetObject = GameObject.FindGameObjectWithTag("Player");

            if (PlayertargetObject != null)
            {
                // Spróbuj pobraæ komponent BaseStats z obiektu gracza
                playerBaseStats = PlayertargetObject.GetComponent<BaseStats>();

                if (playerBaseStats == null)
                {
                    Debug.LogWarning("Player object doesn't have a BaseStats component.");
                }
            }
            else
            {
                Debug.LogWarning("No object with the 'Player' tag found in the scene.");
            }
        }

        private void Awake()
        {

            LogicWeponOrEnemy = GetComponent<DamageOnTouch>();
            //defence = new LazyValue<float>(GetInitialMinDamage);
            minDamage = new LazyValue<float>(GetInitialMinDamage);
            maxDamage = new LazyValue<float>(GetInitialMaxDamage);
            
        }


        
        void Update()
        {
            ToSameDamage();
            
        }

        


       // public float GetInitialDefense()
        //{
           // return playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.Defence);
            // return GetComponent<BaseStats>().GetStat(Stats.Stat.MinDamage);
       // }

        public float GetInitialMinDamage()
        {
            return playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.MinDamage);
           // return GetComponent<BaseStats>().GetStat(Stats.Stat.MinDamage);
        }
        public float GetInitialMaxDamage()
        {
            return playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.MaxDamage);
            //return GetComponent<BaseStats>().GetStat(Stats.Stat.MaxDamage);
        }

        // notatka
        // to sie ³aczy z logic wepon, a wiec zrób tak:
        //1) ¿eby pobiera³o obra¿enia z playera // characteru
        //2) ¿eby obliza³o obra¿enia z celu
        // patrz dok³adnie na float z filmiku


        private void ToSameDamage()
        {
            // Sprawdzanie czy obiekt celu ma skrypt BaseStats
            LogicWeponOrEnemy = targetObject.GetComponent <DamageOnTouch>();
            if (targetObject == null )
            {
                return;
            }

            minDamage.value = playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.MinDamage);
            maxDamage.value = playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.MaxDamage);
            LogicWeponOrEnemy.MinDamageCaused = minDamage.value;
            LogicWeponOrEnemy.MaxDamageCaused = maxDamage.value;

            BaseStats targetBaseStats = targetObject.GetComponent<BaseStats>();
            if (PlayertargetObject != null)
            {
                float defence = PlayertargetObject.GetComponent<BaseStats>().GetStat(Stats.Stat.Defence);
                //LogicWeponOrEnemy.MinDamageCaused =  minDamage.value - defence;
                // LogicWeponOrEnemy.MaxDamageCaused =   maxDamage.value - defence;

                LogicWeponOrEnemy.MinDamageCaused /= 1 + defence / minDamage.value;
                LogicWeponOrEnemy.MaxDamageCaused /= 1 + defence / maxDamage.value;

                //defence.value = targetObject.GetComponent<BaseStats>().GetBaseStat(Stats.Stat.Defence);
                //minDamage.value = playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.MinDamage);
                //  maxDamage.value = playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.MaxDamage);
                // LogicWeponOrEnemy.MinDamageCaused = minDamage.value - defence.value;
                // LogicWeponOrEnemy.MaxDamageCaused = maxDamage.value - defence.value;

                // minDamage.value /= 1 + defence.value / minDamage.value;
                // maxDamage.value /= 1 + defence.value / maxDamage.value;

                /* if (minDamageCaused <= 0)
                 {
                     minDamageCaused = 0;
                 }

                 if (maxDamageCaused <= 0)
                 {
                     maxDamageCaused = 0;
                 }

                 DamageOnTouch LogicWeponOrEnemy = new DamageOnTouch();
                 LogicWeponOrEnemy.MinDamageCaused = minDamageCaused;
                 LogicWeponOrEnemy.MaxDamageCaused = maxDamageCaused;

                 // Wykonaj dzia³ania zwi¹zane z obra¿eniami (np. przekazanie ich do systemu walki)*/
            }



            /*Debug.Log("Attacking: " );
            if (targetObject == null )
            {
                return;
            }
            DamageOnTouch LogicWeponOrEnemy = GetComponent<DamageOnTouch>();
            minDamage.value = playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.MinDamage);
            maxDamage.value = playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.MaxDamage);
            defence.value = playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.Defence);

            LogicWeponOrEnemy.MinDamageCaused = minDamage.value;
            LogicWeponOrEnemy.MaxDamageCaused = maxDamage.value;

            
            BaseStats playerBaseStats = targetObject.GetComponent<BaseStats>();
            if (playerBaseStats != null || LogicWeponOrEnemy != null)
            {
                defence.value = playerBaseStats.GetStat(Stats.Stat.Defence);
                minDamage.value /= 1 + defence.value / minDamage.value;
                maxDamage.value /= 1 + defence.value / maxDamage.value;

                LogicWeponOrEnemy.MinDamageCaused = minDamage.value;
                LogicWeponOrEnemy.MaxDamageCaused = maxDamage.value;
            }*/


            /* LogicWeponOrEnemy = playerCharacter.GetComponent<DamageOnTouch>();
             //update\/
             BaseStats playerBaseStats = playerCharacter.GetComponent<BaseStats>();

             defence.value = playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.Defence);
             minDamage.value = playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.MinDamage);
             maxDamage.value = playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.MaxDamage);

             //BaseStats targetBaseStats = targetObject.GetComponent<BaseStats>();
             if (playerBaseStats != null)
             {

                 defence.value = playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.Defence);
                 minDamage.value = playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.MinDamage);
                 maxDamage.value = playerCharacter.GetComponent<BaseStats>().GetStat(Stats.Stat.MaxDamage);

                 BaseStats targetBaseStats = targetObject.GetComponent<BaseStats>();
                 if (targetBaseStats != null)
                 {
                     float targetDefence = targetBaseStats.GetStat(Stats.Stat.Defence);

                     if (LogicWeponOrEnemy != null)
                     {
                         LogicWeponOrEnemy.MinDamageCaused = Mathf.Max(minDamage.value - targetDefence, 1);
                         LogicWeponOrEnemy.MaxDamageCaused = Mathf.Max(maxDamage.value - targetDefence, 1);
                     }
                 }*/
            /*if (LogicWeponOrEnemy != null)
            {
                LogicWeponOrEnemy.MinDamageCaused = minDamage.value - defence.value;
                if (LogicWeponOrEnemy.MinDamageCaused <= 0)
                {
                    LogicWeponOrEnemy.MinDamageCaused = 1;
                }
                LogicWeponOrEnemy.MaxDamageCaused = maxDamage.value - defence.value;
                if (LogicWeponOrEnemy.MaxDamageCaused <= 0)
                {
                    LogicWeponOrEnemy.MaxDamageCaused = 1;
                }
            }*/
        }



        // BaseStats targetBaseStats = targetObject.GetComponent<BaseStats>();
        //if (targetBaseStats != null)
        //  {
        // float defence = targetBaseStats.GetComponent<BaseStats>().GetStat(Stats.Stat.Defence);
        // minDamage.value /= 1 + defence.value / minDamage.value;
        //maxDamage.value /= 1 + defence.value / maxDamage.value;
        // }*/
    }
       
        }
    

