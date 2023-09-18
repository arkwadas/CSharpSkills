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

namespace RPG.Combat
{
    public class UpdateHealth : MonoBehaviour, ISaveable
    {
        
        protected Health _health;
        private float regenerationPercentage;
        [SerializeField] TakeDamageEvent takeDamage;
        public UnityEvent onDie;

        [System.Serializable]
        public class TakeDamageEvent : UnityEvent<float>
        {
        }


        LazyValue<float> healthPoints;
        bool wasDeadLastFrame = false;

        //test
        private void Awake()
        {
            _health = GetComponent<Health>();
            healthPoints = new LazyValue<float>(GetInitialHealth);
        }

        private void Update()
        {
           // UpdatesHealth();
           // MMGetHealth();
            //MMMaxHealth();
            ToSameHealth();
        }

        public float GetInitialHealth()
        {
            return GetComponent<BaseStats>().GetStat(Stats.Stat.Health);
        }

        private void Start()
        {
            //healthPoints.ForceInit();
            //MMCurrentHealth(); to usunalem bo sie przy czytywaniu ³adowa³o cale ¿ycie
        }

        public void ToSameHealth()
        {
            //_health = GetComponent<Health>();
            //_health.CurrentHealth = healthPoints.value;
            healthPoints.value = _health.CurrentHealth;
        }

        private void OnEnable()
        {
            GetComponent<BaseStats>().onLevelUp += RegenerateHealth; // Tak dodajemy do akcji kolejne efekty np wieksza si³a itp.
        }

        private void OnDisable()
        {
            GetComponent<BaseStats>().onLevelUp -= RegenerateHealth;
        }

        public bool IsDead()
        {
            return healthPoints.value <= 0;
        }

        public void TakeDamage(GameObject instigator, float damage)
        {
            healthPoints.value = Mathf.Max(healthPoints.value - damage, 0);

            if (IsDead())
            {
                onDie.Invoke();
                AwardExperience(instigator);
            }
            else
            {
                takeDamage.Invoke(damage);
            }
            //UpdateState();
        }
        private void UpdateState()
        {
            Animator animator = GetComponent<Animator>();
            if (!wasDeadLastFrame && IsDead())
            {
                animator.SetTrigger("die");
                GetComponent<ActionScheduler>().CancelCurrentAction();
            }

            if (wasDeadLastFrame && !IsDead())
            {
                animator.Rebind();
            }

            wasDeadLastFrame = IsDead();
        }

        public float UpdatesHealth()
        {
            _health = GetComponent<Health>();

            float healthInitialValue = healthPoints.value;
            _health.InitialHealth = healthInitialValue;
            //healthInitialValue = _health.InitialHealth;
            if (_health.CurrentHealth > _health.MaximumHealth)
            {
                _health.CurrentHealth = _health.MaximumHealth;
            }
           return healthInitialValue;
        }

        public float MMCurrentHealth()
        {
            _health = GetComponent<Health>();
            float currentValue = MaxHealth();
            _health.CurrentHealth = MaxHealth(); 
            //_health.CurrentHealth = currentValue;
            return currentValue;
        }

        public void Heal(float healthToRestore)
        {
            healthPoints.value = Mathf.Min(healthPoints.value + healthToRestore, MaxHealth());
            UpdateState();
        }

        public void AnatherHeal(float healthToRestore)
        {
            _health.CurrentHealth = Mathf.Min(_health.CurrentHealth + healthToRestore, _health.MaximumHealth);
        }

        public void UpdatessHealth(GameObject instigator)
        {
            _health.CurrentHealth = Mathf.Max(_health.CurrentHealth, 0);
            if (_health.CurrentHealth == 0)
            {
                AwardExperience(instigator);
            }
        }

        public float GetHealth()
        {
            /*_health = GetComponent<Health>();
            float healthValue = stats.GetBaseStat(Stats.Stat.Health);
            _health.InitialHealth = healthValue;
            _health.CurrentHealth = healthValue;
            _health.MaximumHealth = healthValue;

            return healthValue;*/
            return healthPoints.value;
        }
        public float MMGetHealth()
        {
            _health = GetComponent<Health>();
            float healthValue = GetHealth();
            return healthValue;
        }


        public float MaxHealth()
        {
            return GetComponent<BaseStats>().GetStat(Stats.Stat.Health);
        }
        
        public float MMMaxHealth()
        {
           // _health = GetComponent<Health>();
            float healthPoints = MaxHealth();
            _health.MaximumHealth = healthPoints;
            return healthPoints;
        }

        private void AwardExperience(GameObject instigator)
        {
            Experience experience = instigator.GetComponent<Experience>();
            if (experience == null) return;

            float experienceReward = GetComponent<BaseStats>().GetStat(Stats.Stat.ExperienceReward);
            experience.GainExperience(experienceReward);
        }

        private void RegenerateHealth()
        {
            float regenHealthPoints = GetComponent<BaseStats>().GetStat(Stats.Stat.Health) * (regenerationPercentage / 100);
            _health.CurrentHealth = Mathf.Max(_health.CurrentHealth, regenHealthPoints);
        }

        public float GetPercentage()
        {
            return 100 * GetFraction();
        }

        public float GetFraction()
        {
            return healthPoints.value / GetComponent<BaseStats>().GetStat(Stats.Stat.Health);
        }

        public void AwardExp(GameObject instigator)
        {
            if (_health.CurrentHealth == 0)
            {
                AwardExperience(instigator);
            }
        }

        public object CaptureState()
        {
            //healthValue.
            return healthPoints.value;
        }

        public void RestoreState(object state)
        {
            healthPoints.value = (float)state;
           // healthValue.value =
            UpdateState();
        }
    }

}
