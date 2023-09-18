using System;
using UnityEngine;
using GameDevTV.Inventories;
using RPG.Stats;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using RPG.Control;
using RPG.Customization;
using UnityEditor;
//using Object = System.Object;

namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
    public class WeaponConfig : EquipableItem, IModifierProvide
    {
        public CharacterClass characterClass;
        [SerializeField] AnimatorOverrideController animatorOverride = null;

        [SerializeField] Weapon equippedPrefab = null;
        [SerializeField] Weapon equippedPrefab2 = null;

        Equipment equipment;
        [SerializeField] float weaponDamage = 5f;
        [SerializeField] float weaponMaxDamage = 5f;
        [SerializeField] float percentageBonus = 0;
        [SerializeField] float weaponRange = 2f;

        //[SerializeField] bool isRightHanded = true;

        public bool isTwoHanded = false;
        public bool isDualWield = false;

        [SerializeField] Projectile projectile = null;
        [SerializeField] float timeBetweenShots = 0.5f;

        [SerializeField] float attackBonus = 1;
        public enum WeaponHands { right, left, both }
        [SerializeField] WeaponHands mainHand;

  

        [SerializeField] int newId;

        const string weaponName = "Weapon";
        const string weaponName2 = "Weapon2";


        private void SetManArmorPancerzId()
        {
            CharacterCustomization characterCustomization = FindObjectOfType<CharacterCustomization>();
            characterCustomization.SetManArmorPancerzId(newId);
        }


        public Weapon Spawn(Transform rightHand, Transform leftHand, Animator animator)
         {
            DestroyOldWeapon(rightHand, leftHand);
            DestroyOtherWeapon(rightHand, leftHand);

            //ActivateOutfill();
            Weapon weapon = null;
            Weapon weapon2 = null;

            /* if (equippedPrefab != null)
              {
                  Transform handTransform = GetTransform(rightHand, leftHand);
                  weapon = Instantiate(equippedPrefab, handTransform);
                  weapon.gameObject.name = weaponName;
                  SetManArmorPancerzId();

             }*/
            if (equippedPrefab != null)
            {
                Transform handTransform = GetMainHand(rightHand, leftHand);
                if (mainHand == WeaponHands.left)
                {
                    weapon = Instantiate(equippedPrefab, handTransform);
                }
                if (mainHand == WeaponHands.right)
                {
                    weapon = Instantiate(equippedPrefab, handTransform);

                }
                if (mainHand == WeaponHands.both)
                {
                    weapon = Instantiate(equippedPrefab, rightHand);
                    if (equippedPrefab2 != null && isDualWield)
                    {
                        weapon2 = Instantiate(equippedPrefab2, leftHand);
                        weapon2.gameObject.name = weaponName2;
                    }

                }
                weapon.gameObject.name = weaponName; //this... (-_-)
            }


            Animator weaponAnimator = weapon.GetComponentInChildren<Animator>();
            if (weaponAnimator != null)
            {
                // If the Animator component is found, set it to the provided animator parameter.
                animator = weaponAnimator;
            }

            var overrideController = animator.runtimeAnimatorController as AnimatorOverrideController;
            if (animatorOverride != null)
            {
                animator.runtimeAnimatorController = animatorOverride; 
            }
            else if (overrideController != null)
            {
                animator.runtimeAnimatorController = overrideController.runtimeAnimatorController;
            }

            return weapon;
        }



        private void DestroyOldWeapon(Transform rightHand, Transform leftHand)
        {
            Transform oldWeapon = rightHand.Find(weaponName);
            if (oldWeapon == null)
            {
                oldWeapon = leftHand.Find(weaponName);
            }
            if (oldWeapon == null) return;

            oldWeapon.name = "DESTROYING";
            Destroy(oldWeapon.gameObject);
        }

        private void DestroyOtherWeapon(Transform rightHand, Transform leftHand)
        {
            Transform oldWeapon2 = leftHand.Find(weaponName2);

            if (oldWeapon2 == null)
            {
                oldWeapon2 = rightHand.Find(weaponName2);
            }

            if (oldWeapon2 == null) return;

            oldWeapon2.name = "DESTROYING";

            Destroy(oldWeapon2.gameObject);
        }


      /*  private Transform GetTransform(Transform rightHand, Transform leftHand)
        {
            Transform handTransform;
            if (isRightHanded) handTransform = rightHand;
            else handTransform = leftHand;
            return handTransform;
        }*/

        //Replaced GetTransform() with GetMainHand()
        private Transform GetMainHand(Transform rightHand, Transform leftHand)
        {
            Transform handTransform;
            if (mainHand == WeaponHands.right) return rightHand;
            if (mainHand == WeaponHands.left) return leftHand;
            if (mainHand == WeaponHands.both)
            {
                if (rightHand && !leftHand)
                {
                    return rightHand;
                }
                if (leftHand && !rightHand)
                {
                    return leftHand;
                }
            }
            return handTransform = rightHand;
        }

        public bool HasProjectile()
        {
            return projectile != null;
        }

        public void LaunchProjectile(Health target ,Transform rightHand, Transform leftHand, Transform target2, GameObject instigator, float calculateDamage)
        {
            Projectile projectileInstant = Instantiate(projectile, /*w razie w do zmianyGetTransform*/GetMainHand(rightHand, leftHand).position, Quaternion.identity);
            projectileInstant.SetTarget(target, instigator, calculateDamage);
            projectileInstant.Init(target2.forward, instigator);
        }
        /*public void LaunchProjectile(Transform target, GameObject instigator, float calculateDamage)
        {
            Projectile projectileInstant = Instantiate(projectile, target.position, Quaternion.identity);
            projectileInstant.Init(target.forward, instigator);
        }*/


        private Vector3 GetMouseWorldPosition()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            return Camera.main.ScreenToWorldPoint(mousePos);
        }

        public float GetDamage()
        {
            return weaponDamage;
        }

        public float GetMaxDamage()
        {
            return weaponMaxDamage;
        }

        public float GetPercentageBonus()
        {
            return percentageBonus;
        }

        public float GetRange()
        {
            return weaponRange;
        }

        public float GetTimeBetweenShots()
        {
            return timeBetweenShots;
        }

        public IEnumerable<float> GetAdditiveModifiers(Stats.Stat stat)
        {
            if (stat == Stats.Stat.MinDamage)
            {
                yield return weaponDamage;
            }
            if (stat == Stats.Stat.MaxDamage)
            {
                yield return weaponMaxDamage;
            }
        }

        public IEnumerable<float> GetPercentageModifiers(Stats.Stat stat)
        {
            if (stat == Stats.Stat.MinDamage)
            {
                yield return weaponDamage;
            }
            if (stat == Stats.Stat.MaxDamage)
            {
                yield return weaponMaxDamage;
            }
        }
        /*public float GetWeaponAnimTime(Animator animator)
        {
            return animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        }
        */
        public void PlayAttackSFX(Weapon weapons)
        {
           
            weapons.OnHit();
        }

        public IEnumerable<float> GetAdditiveModifier(Stats.Stat stat)
        {
            if (stat == Stats.Stat.MinDamage)
            {
                yield return percentageBonus;
            }
            if (stat == Stats.Stat.MaxDamage)
            {
                yield return percentageBonus;
            }
        }

            public IEnumerable<float> GetProcentageModifire(Stats.Stat stat)
        {
            if (stat == Stats.Stat.Health)
            {
                yield return weaponDamage;
            }
            
        }

        #region InventoryItemEditor Additions

        public override string GetDescription()
        {
            string result = projectile ? "Ranged Weapon" : "Melee Weapon";
            result += $"\n\n{GetRawDescription()}\n";
            result += $"\nRange {weaponRange} meters";
            result += $"\nBase Damage {weaponDamage} points";
            if ((int)percentageBonus != 0)
            {
                string bonus = percentageBonus > 0 ? "<color=#8888ff>bonus</color>" : "<color=#ff8888>penalty</color>";
                result += $"\n{(int)percentageBonus} percent {bonus} to attack.";
            }
            return result;
        }

#if UNITY_EDITOR

        void OnValidate()
        {
            if (GetAllowedEquipLocation() != EquipLocation.Weapon)
            {
                SetAllowedEquipLocation(EquipLocation.Weapon);
            }
        }

        void SetWeaponRange(float newWeaponRange)
        {
            if (FloatEquals(weaponRange, newWeaponRange)) return;
            SetUndo("Set Weapon Range");
            weaponRange = newWeaponRange;
            Dirty();
        }

        void SetWeaponDamage(float newWeaponDamage)
        {
            if (FloatEquals(weaponDamage, newWeaponDamage)) return;
            SetUndo("Set Weapon Damage");
            weaponDamage = newWeaponDamage;
            Dirty();
        }

        void SetPercentageBonus(float newPercentageBonus)
        {
            if (FloatEquals(percentageBonus, newPercentageBonus)) return;
            SetUndo("Set Percentage Bonus");
            percentageBonus = newPercentageBonus;
            Dirty();
        }

        /*void SetIsRightHanded(bool newRightHanded)
        {
            if (isRightHanded == newRightHanded) return;
            SetUndo(newRightHanded ? "Set as Right Handed" : "Set as Left Handed");
            isRightHanded = newRightHanded;
            Dirty();
        }*/

        void SetAnimatorOverride(AnimatorOverrideController newOverride)
        {
            if (newOverride == animatorOverride) return;
            SetUndo("Change AnimatorOverride");
            animatorOverride = newOverride;
            Dirty();
        }

        void SetEquippedPrefab(GameObject potentialnewWeapon)
        {
            if (!potentialnewWeapon)
            {
                SetUndo("No Equipped Prefab");
                equippedPrefab = null;
                Dirty();
                return;
            }
            if (!potentialnewWeapon.TryGetComponent(out Weapon newWeapon)) return;
            if (newWeapon == equippedPrefab) return;
            SetUndo("Set Equipped Prefab");
            equippedPrefab = newWeapon;
            Dirty();
        }

        void SetProjectile(GameObject potentialNewProjectile)
        {
            if (!potentialNewProjectile)
            {
                SetUndo("No Projectile");
                projectile = null;
                Dirty();
                return;
            }
            if (!potentialNewProjectile.TryGetComponent(out Projectile newProjectile))
            {
                return;
            }
            if (newProjectile == projectile) return;
            SetUndo("Set Projectile");
            projectile = newProjectile;
            Dirty();
        }

        public override bool IsLocationSelectable(Enum location)
        {
            EquipLocation candidate = (EquipLocation)location;
            return candidate == EquipLocation.Weapon;
        }

        bool drawWeaponConfigData = true;
        public override void DrawCustomInspector()
        {
            base.DrawCustomInspector();
            drawWeaponConfigData = EditorGUILayout.Foldout(drawWeaponConfigData, "WeaponConfig Data", foldoutStyle);
            if (!drawWeaponConfigData) return;
            EditorGUILayout.BeginVertical(contentStyle);
            //Trick to allow searching for the prefab using the . button instead of having to drag it in
            GameObject potentialPrefab = equippedPrefab ? equippedPrefab.gameObject : null;
            SetEquippedPrefab((GameObject)EditorGUILayout.ObjectField("Equipped Prefab", potentialPrefab, typeof(GameObject), false));
            SetWeaponDamage(EditorGUILayout.Slider("Weapon Damage", weaponDamage, 0, 100));
            SetWeaponRange(EditorGUILayout.Slider("Weapon Range", weaponRange, 1, 40));
            SetPercentageBonus(EditorGUILayout.IntSlider("Percentage Bonus", (int)percentageBonus, -10, 100));
           // SetIsRightHanded(EditorGUILayout.Toggle("Is Right Handed", isRightHanded));
            SetAnimatorOverride((AnimatorOverrideController)EditorGUILayout.ObjectField("Animator Override", animatorOverride, typeof(AnimatorOverrideController), false));
            GameObject potentialProjectile = projectile ? projectile.gameObject : null;
            SetProjectile((GameObject)EditorGUILayout.ObjectField("Projectile", potentialProjectile, typeof(GameObject), false));
            EditorGUILayout.EndVertical();
        }

#endif
        #endregion

    }
}
