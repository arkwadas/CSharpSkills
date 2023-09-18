using UnityEngine;
using MoreMountains.Tools;
using System;
using GameDevTV.Inventories;

namespace MoreMountains.InventoryEngine
{
	[CreateAssetMenu(fileName = "EquippableWeaponItemWrapper", menuName = "MoreMountains/InventoryEngine/EquippableWeaponItemWrapper", order = 2)]
	[Serializable]
	/// <summary>
	/// Demo class for a wrapper class for a weapon item that can be equipped
	/// </summary>
	public class EquippableWeaponItemWrapper : ScriptableObject
	{
		public WeaponItem weaponItem;
		public EquipableItem equipableItem;

		public EquippableWeaponItemWrapper(WeaponItem weapon, EquipableItem equip)
		{
			this.weaponItem = weapon;
			this.equipableItem = equip;
		}

		public EquipLocation GetAllowedEquipLocation()
		{
			return equipableItem.GetAllowedEquipLocation();
		}
	}
}

