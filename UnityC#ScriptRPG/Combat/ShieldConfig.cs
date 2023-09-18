using System.Collections.Generic;
using UnityEngine;
using GameDevTV.Inventories;
using RPG.Stats;

namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "Shield", menuName = "Shields/Make New Shield", order = 0)]
    public class ShieldConfig : EquipableItem, IModifierProvide
    {
        [SerializeField] Shield equippedPrefab;
        [SerializeField] bool isRightHanded;

        [SerializeField] float defenseBonus = 0;
        [SerializeField] float percentageBonus = 0;

        const string shieldName = "Shield";
        public Shield SpawnEquipableItem(Transform rightHand, Transform leftHand)
        {
            DestroyOldEquipableItem(rightHand, leftHand);

            Shield shield = null;
            if (equippedPrefab != null)
            {
                Transform handTransform = GetTransform(rightHand, leftHand);
                shield = Instantiate(equippedPrefab, handTransform);
                shield.gameObject.name = shieldName;
            }

            return shield;
        }

        public Transform GetTransform(Transform rightHand, Transform leftHand)
        {
            Transform handTransform;
            if (isRightHanded) handTransform = rightHand;
            else handTransform = leftHand;
            return handTransform;
        }

        void DestroyOldEquipableItem(Transform rightHand, Transform leftHand)
        {
            Transform oldWeapon = rightHand.Find(shieldName);
            if (oldWeapon == null)
            {
                oldWeapon = leftHand.Find(shieldName);
            }
            if (oldWeapon == null) return;

            oldWeapon.name = "DESTROYING";
            Destroy(oldWeapon.gameObject);
        }
        //Add Armor to enum in Stats.cs
       

        public IEnumerable<float> GetAdditiveModifier(Stat stat)
        {
            if (stat == Stat.Defence)
            {
                yield return defenseBonus;
            }
        }

        public IEnumerable<float> GetProcentageModifire(Stat stat)
        {
            if (stat == Stat.Defence)
            {
                yield return percentageBonus;
            }
        }
    }
}