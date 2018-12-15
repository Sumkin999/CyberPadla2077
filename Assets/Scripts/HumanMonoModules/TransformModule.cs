using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.HumanMonoModules
{
    public class TransformModule:MonoBehaviour
    {
        public AnimatorModule AnimatorModule;


        public Transform MainTransform;
        public Rigidbody RigidbodyMain;

        public NavMeshAgent NavMeshAgent;

        public Vector3 TargetVector3;

        public float VelocitySmooth = 10;

        public void Move()
        {
            //TargetVector3 = MainTransform.forward;
            NavMeshAgent.destination = TargetVector3;// SetDestination(TargetVector3);//=TargetVector3;
            NavMeshAgent.isStopped = false;


            Vector3 reletiveVelocity = MainTransform.InverseTransformVector(NavMeshAgent.velocity);

            AnimatorModule.Animator.SetFloat("WalkRight", Mathf.Lerp(AnimatorModule.Animator.GetFloat("WalkRight"), reletiveVelocity.x, Time.deltaTime * VelocitySmooth));
            AnimatorModule.Animator.SetFloat("WalkForward", Mathf.Lerp(AnimatorModule.Animator.GetFloat("WalkForward"), reletiveVelocity.z, Time.deltaTime * VelocitySmooth));

            //RigidbodyMain.MovePosition(RigidbodyMain.transform.position + TargetVector3 * Time.deltaTime);


            //MainTransform.Translate(TargetVector3*Time.deltaTime);
        }
    }
}
