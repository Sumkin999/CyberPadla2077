using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules.RagdollFolder;
using UnityEngine;

namespace Assets.Scripts.HumanMonoModules
{
    public class PhysicsModule:MonoBehaviour
    {
        protected FacadeHumanMono _facadeHuman;

        public void InicPhysicModule(FacadeHumanMono facadeHumanMono)
        {
            _facadeHuman = facadeHumanMono;
        }

        public HumanRagdoll HumanRagdoll;



    }
}
