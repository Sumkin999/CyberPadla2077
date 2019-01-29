using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;
using Assets.Scripts.WeaponsFolder.ConcreteWeaponsFolder.WeaponMonoFolder;
using Assets.Scripts.WeaponsFolder.WeaponAttacksFolder;
using UnityEngine;

namespace Assets.Scripts.WeaponsFolder
{
    [Serializable]
    public class WeaponFist:WeaponBase
    {
        public WeaponFist(WeaponModuleMethodsHolder weaponModuleMethodsHolder):base(weaponModuleMethodsHolder)
        {

            EnumWeaponType=EnumWeaponType.Fists;

            InstantiateMonoForThisWeapon();
            WeaponModuleMethodsHolder = weaponModuleMethodsHolder;

            //WeaponVisuals = new WeaponVisuals();

            PotencialAttacks.Add(new WeaponAttackFistHit(WeaponModuleMethodsHolder));

        }
        public WeaponFistMono WeaponFistMono;
        public float HitTimerCurrent;

        public override void AdditionalUpdateAction()
        {
            if (HitTimerCurrent > 0)
            {
                HitTimerCurrent -= Time.deltaTime;
            }
        }

        public override void WeaponSelectedAction()
        {
            Debug.Log("Fist Selected!");
            WeaponFistMono.gameObject.SetActive(true);
        }

        public override void WeaponDeselectedAction()
        {
            Debug.Log("Fist Hided!");
            WeaponFistMono.gameObject.SetActive(false);
        }

        public override void StateBreakAction()
        {
            WeaponFistMono.DeactivateHit();
        }
    }
}
