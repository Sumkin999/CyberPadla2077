using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void ToggleAim(bool aimBool)
        {
            Animator.SetBool("IsAiming", aimBool);
        }

        public void SetWalkBlendDirection(Vector3 relativeVector,float velocitySmooth)
        {
            Animator.SetFloat("WalkRight", Mathf.Lerp(Animator.GetFloat("WalkRight"), relativeVector.x, Time.deltaTime * velocitySmooth));
            Animator.SetFloat("WalkForward", Mathf.Lerp(Animator.GetFloat("WalkForward"), relativeVector.z, Time.deltaTime * velocitySmooth));
        }
    }
}
