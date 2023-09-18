using GameDevTV.Utils;
//using RPG.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Stats;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;
using MoreMountains.TopDownEngine;
using RPG.Combat;
using GameDevTV.Inventories;
using RPG.Invetories;
using TMPro;
using GameDevTV.Saving;

//namespace RPG.Stats
namespace MoreMountains.Tools
{
    /// <summary>
    /// TODO_DESCRIPTION
    /// </summary>
    //[AddComponentMenu("More Mountains/Tools/GUI/MMHealthBar")]

    public class BaseStats : MonoBehaviour, ISaveable
    {
        [Range(1, 99)]
        [SerializeField] int startingLevel = 1;
        public CharacterClass characterClass;
        public Progression progression = null;
         // WYWO£ANIE EFFEKTU!!! PONI¯EJ METODA I WYWO£ANIE DO NIEGO
        [SerializeField] bool shouldUseModifires = false;


        public event Action onLevelUp;

        LazyValue<int> currentLevel;
        Experience experience;

        protected Health _health;



        public virtual void Awake()
        {
            // Initialization();
            experience = GetComponent<Experience>();
            currentLevel = new LazyValue<int>(CalculateLevel);
            
        }

        private void Start()
        {
            currentLevel.ForceInit();
        }


        private void OnEnable()
        {
            if (experience != null)
            {
                experience.OnExperienceGained += UpdateLevel;
            }
        }

        private void OnDisable()
        {
            if (experience != null)
            {
                experience.OnExperienceGained -= UpdateLevel;
            }
        }

        private void UpdateLevel()
        {
            int newLevel = CalculateLevel();
            if (newLevel > currentLevel.value)
            {
                currentLevel.value = newLevel;
                //LevelUpEffect(); // WYWO£ANIE W UPDACIE LEVELU ALE TAK SMAO MO¯E BYÆ DO UFERZENIA!

                if (onLevelUp != null)
                {
                    onLevelUp();
                }
            }

        }

        

        
        public float GetStat(Stat stat)
        {
            return (GetBaseStat(stat) + GetAdditiveModifier(stat)) * (1 + GetProcentageModifire(stat) / 100);
        }



        public float GetBaseStat(Stat stat)
        {
            return progression.GetStat(stat, characterClass, GetLevel());
        }


        public int GetLevel()
        {

            return currentLevel.value;
        }

        
            private float GetAdditiveModifier(Stat stat)
            {
                if (!shouldUseModifires) return 0;

                float total = 0;
                foreach (IModifierProvide provider in GetComponents<IModifierProvide>())
                {
                    foreach (float modifier in provider.GetAdditiveModifier(stat))
                    {
                        total += modifier;
                    }
                }
                return total;
            }
        

        private float GetProcentageModifire(Stat stat)
        {
            if (!shouldUseModifires) return 0;
            float total = 0;
            foreach (IModifierProvide provide in GetComponents<IModifierProvide>())
            {
                foreach (float modifiers in provide.GetProcentageModifire(stat))
                {
                    total += modifiers;
                }
            }
            return total;
        }

        public int CalculateLevel()
        {
            Experience experience = GetComponent<Experience>();

            if (experience == null) return startingLevel;

            float currentXP = experience.GetPoints();
            int penultimateLevel = progression.GetLevels(Stat.ExperienceToLevelUp, characterClass);
            for (int level = 1; level <= penultimateLevel; level++)
            {
                float XPToLevelUP = progression.GetStat(Stat.ExperienceToLevelUp, characterClass, level);
                if (XPToLevelUP > currentXP)
                {
                    return level;
                }
            }
            return penultimateLevel + 1;
        }

        public object CaptureState()
        {
            return currentLevel.value;
        }

        public void RestoreState(object state)
        {
            currentLevel.value = (int)state;
        }
    }
}
