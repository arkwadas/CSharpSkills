using UnityEngine;
using System.Collections;
using MoreMountains.Tools;

namespace MoreMountains.TopDownEngine
{
    [AddComponentMenu("TopDown Engine/Character/Abilities/DeflectShots")]
    public class DeflectShots : CharacterAbility
    {
        public override string HelpBoxText() { return "This ability allows the character to deflect incoming shots using a collider."; }

        [Header("Deflect Shots")]
        [MMInformation("Add a collider to the character's game object to use as the deflector. Set the collider's isTrigger to true.", MMInformationAttribute.InformationType.Info, false)]
        public float DeflectChance = 0.8f;
        public GameObject DeflectEffect;

        protected override void Initialization()
        {
            base.Initialization();
        }

        public override void ProcessAbility()
        {
            base.ProcessAbility();
        }

        protected override void HandleInput()
        {
            // nothing to do here
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (!AbilityPermitted
                || (_condition.CurrentState != CharacterStates.CharacterConditions.Normal))
            {
                return;
            }
            if (other.CompareTag("Projectile"))
            {
                DeflectShot(other);
            }
        }

        protected virtual void DeflectShot(Collider shot)
        {
            float randomChance = Random.Range(0f, 1f);
            if (randomChance <= DeflectChance)
            {
                //MMDebug.("Shot deflected!");
                ReflectProjectile(shot);
                if (DeflectEffect != null)
                {
                    GameObject effect = Instantiate(DeflectEffect, shot.transform.position, shot.transform.rotation);
                }
            }
        }

        protected virtual void ReflectProjectile(Collider shot)
        {
            Rigidbody rb = shot.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 reflectDirection = Vector3.Reflect(rb.velocity, shot.transform.forward);
                rb.velocity = reflectDirection;
            }
        }

        protected override void InitializeAnimatorParameters()
        {
            // nothing to do here
        }

        public override void UpdateAnimator()
        {
            // nothing to do here
        }
    }
}
