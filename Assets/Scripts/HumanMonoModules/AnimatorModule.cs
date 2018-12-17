using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.WeaponsFolder;
using UnityEditor.Animations;
using UnityEngine;

namespace Assets.Scripts.HumanMonoModules
{
    public class AnimatorModule:MonoBehaviour
    {
        public Animator Animator;

        public void ToggleWalk(bool walkbool)
        {
            Animator.SetBool("Walk",walkbool);
        }

        public void ToggleAim(bool aimBool,WeaponBase weaponBase)
        {
            

            WeaponFist weaponFist=weaponBase as WeaponFist;
            if (weaponFist!=null)
            {
                return;    
            }
            WeaponPistol weaponPistol=weaponBase as WeaponPistol;

            if (weaponPistol!=null)
            {
                Animator.SetBool("IsAiming", aimBool);
                return;
            }

            WeaponUzi weaponUzi=weaponBase as WeaponUzi;
            if (weaponUzi!=null)
            {
                Animator.SetBool("IsAiming2",aimBool);
                return;
            }
           
        }

        public void SetWalkBlendDirection(Vector3 relativeVector,float velocitySmooth)
        {
            Animator.SetFloat("WalkRight", Mathf.Lerp(Animator.GetFloat("WalkRight"), relativeVector.x, Time.deltaTime * velocitySmooth));
            Animator.SetFloat("WalkForward", Mathf.Lerp(Animator.GetFloat("WalkForward"), relativeVector.z, Time.deltaTime * velocitySmooth));
        }
    }
}
