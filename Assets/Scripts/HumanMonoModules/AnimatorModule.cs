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
    }
}
