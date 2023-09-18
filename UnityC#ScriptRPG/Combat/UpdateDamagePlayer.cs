using System.Collections;
using System.Collections.Generic;
using GameDevTV.Utils;
using UnityEngine;
using RPG.Stats;
using MoreMountains.TopDownEngine;
using MoreMountains.Tools;
public class UpdateDamagePlayer : MonoBehaviour
{

        public BaseStats playerCharacter = null;
        public DamageOnTouch LogicWeponPlayer = null;
    public GameObject targetObject = null;


        LazyValue<float> minDamage;
        LazyValue<float> maxDamage;


        private void Start()
        {
            ToSameDamage();
            
        }

     

        private void Awake()
        {

        LogicWeponPlayer = GetComponent<DamageOnTouch>();
            minDamage = new LazyValue<float>(GetInitialMinDamage);
            maxDamage = new LazyValue<float>(GetInitialMaxDamage);

        }



        void Update()
        {
            ToSameDamage();

        }




   

        public float GetInitialMinDamage()
        {
            return playerCharacter.GetComponent<BaseStats>().GetStat(Stat.MinDamage);
            // return GetComponent<BaseStats>().GetStat(Stats.Stat.MinDamage);
        }
        public float GetInitialMaxDamage()
        {
            return playerCharacter.GetComponent<BaseStats>().GetStat(Stat.MaxDamage);
            //return GetComponent<BaseStats>().GetStat(Stats.Stat.MaxDamage);
        }


        private void ToSameDamage()
        {
       

            minDamage.value = playerCharacter.GetComponent<BaseStats>().GetStat(Stat.MinDamage);
            maxDamage.value = playerCharacter.GetComponent<BaseStats>().GetStat(Stat.MaxDamage);
            LogicWeponPlayer.MinDamageCaused = minDamage.value;
            LogicWeponPlayer.MaxDamageCaused = maxDamage.value;

           



        }
    }
