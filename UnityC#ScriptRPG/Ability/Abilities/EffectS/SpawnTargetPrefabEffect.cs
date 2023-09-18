using MoreMountains.TopDownEngine;
using System;
using System.Collections;
using UnityEngine;

namespace RPG.Abilities.Effects
{
    [CreateAssetMenu(fileName = "Spawn Target Prefab Effect", menuName = "Abilities/Effects/Spawn Target Prefab", order = 0)]
    public class SpawnTargetPrefabEffect : EffectStrategy
    {
        [SerializeField] Transform prefabToSpawn;
        [SerializeField] float destroyDelay = -1;
        [SerializeField] float minDamage;
        [SerializeField] float maxDamage;

        public override void StartEffect(AbilityData data, Action finished)
        {
            data.StartCoroutine(Effect(data, finished));
        }

        private IEnumerator Effect(AbilityData data, Action finished)
        {
            Transform instance = Instantiate(prefabToSpawn);
            instance.position = data.GetTargetedPoint2();

            // Set damage
            DamageOnTouch damageScript = instance.GetComponent<DamageOnTouch>();
            if (damageScript != null)
            {
                damageScript.MinDamageCaused = minDamage;
                damageScript.MaxDamageCaused = maxDamage;
            }

            if (destroyDelay > 0)
            {
                yield return new WaitForSeconds(destroyDelay);
                Destroy(instance.gameObject);
            }
            finished();
        }

        /*public override void StartEffect(AbilityData data, Action finished)
         {
             data.StartCoroutine(Effect(data, finished));
         }

        private IEnumerator Effect(AbilityData data, Action finished)
        {
            Transform instance = Instantiate(prefabToSpawn);
            instance.position = data.GetTargetedPoint2();
            if (destroyDelay > 0)
            {
                yield return new WaitForSeconds(destroyDelay);
                Destroy(instance.gameObject);
            }
            finished();
        }*/

    }
}
