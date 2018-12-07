using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.HumanMonoModules
{
    public class TransformModule:MonoBehaviour
    {
        public Transform MainTransform;

        public Vector3 TargetVector3;

        public void Move()
        {
            TargetVector3 = MainTransform.forward;
            MainTransform.Translate(TargetVector3*Time.deltaTime);
        }
    }
}
