using System.Collections;
using System.Collections.Generic;
using GameDevTV.Inventories;
using RPG.Stats;
using UnityEngine;
using MoreMountains.Tools;

namespace RPG.Inventories
{
    public class StatsEquipment : Equipment, IModifierProvide
    {
        public IEnumerable<float> GetAdditiveModifier(Stats.Stat stat)
        {
            foreach (var slot in GetAllPopulatedSlots())
            {
                var item = GetItemInSlot(slot) as IModifierProvide;
                if (item == null) continue;

                foreach (float modifier in item.GetAdditiveModifier(stat))
                {
                    yield return modifier;
                }
            }
        }

        public IEnumerable<float> GetProcentageModifire(Stats.Stat stat)
        {
            foreach (var slot in GetAllPopulatedSlots())
            {
                var item = GetItemInSlot(slot) as IModifierProvide;
                if (item == null) continue;

                foreach (float modifier in item.GetProcentageModifire(stat))
                {
                    yield return modifier;
                }
            }
        }
    }
}