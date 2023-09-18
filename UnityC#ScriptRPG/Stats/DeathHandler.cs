using UnityEngine;
using RPG.Stats;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;

public class DeathHandler : MonoBehaviour
{
    private Health _health;
    private bool _awardedExperience = false;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        if (_health.CurrentHealth == 0 && !_awardedExperience)
        {
            _awardedExperience = true;

            GameObject player = GameObject.FindWithTag("Player");
            Experience experience = player.GetComponent<Experience>();
            BaseStats enemyBaseStats = GetComponent<BaseStats>();
            experience.GainExperience(enemyBaseStats.GetStat(Stat.ExperienceReward));
        }
    }
}