using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules.AnimatorFolder;
using Assets.Scripts.WeaponsFolder;
using UnityEditor.Animations;
using UnityEngine;

namespace Assets.Scripts.HumanMonoModules
{
    public class AnimatorModule:MonoBehaviour
    {
        public Animator Animator;

        private FacadeHumanMono _facadeHumanMono;

        public AnimatorToWeaponListener AnimatorToWeaponListener;

        public void IniciateAnimatorModule(FacadeHumanMono facadeHumanMono)
        {
            _facadeHumanMono = facadeHumanMono;
            AnimatorToWeaponListener.SetModules(_facadeHumanMono.WeaponModule);
        }

        public void ToggleWalk(bool walkbool)
        {
            Animator.SetBool("Walk",walkbool);
        }

        public void ToggleWeaponHold(WeaponBase weaponBase)
        {
            if (weaponBase.EnumWeaponHoldType==EnumWeaponHoldType.Default)
            {
                Animator.SetBool("HoldShotgun", false);
                Animator.CrossFade("HoldEmpty",0);
                return;
            }
            if (weaponBase.EnumWeaponHoldType==EnumWeaponHoldType.Shotgun)
            {
                Animator.CrossFade("HoldEmpty", 0);
                Animator.SetBool("HoldShotgun",true);
            } 
        }

        public void ToggleNoWeaponHold()
        {
            Animator.SetBool("HoldShotgun", false);
            Animator.CrossFade("HoldEmpty", 0);
        }

        public void SetWalkBlendDirection(Vector3 relativeVector,float velocitySmooth)
        {
            Animator.SetFloat("WalkRight", Mathf.Lerp(Animator.GetFloat("WalkRight"), relativeVector.x, Time.deltaTime * velocitySmooth));
            Animator.SetFloat("WalkForward", Mathf.Lerp(Animator.GetFloat("WalkForward"), relativeVector.z, Time.deltaTime * velocitySmooth));
        }
    }
}
