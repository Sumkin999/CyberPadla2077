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



        public bool PathFindIsOn;
        public Vector3 TargetVector3;

        public Vector3 LookAtVector3;

        public float VelocitySmooth = 10;
        public float RotationSpeed = 180f;

        Vector3 _localTarget=new Vector3();
        public void Move()
        {
            _localTarget = TargetVector3;
            if (PathFindIsOn)
            {
                
            }
            else
            {
                
            }
            //TargetVector3 = MainTransform.forward;
            //NavMeshAgent.destination = TargetVector3;// SetDestination(TargetVector3);//=TargetVector3;
            //NavMeshAgent.isStopped = false;
            RigidbodyMain.MovePosition(MainTransform.position + _localTarget * Time.deltaTime * 1f);

            //Vector3 reletiveVelocity = MainTransform.InverseTransformVector(NavMeshAgent.velocity);

           // AnimatorModule.Animator.SetFloat("WalkRight", Mathf.Lerp(AnimatorModule.Animator.GetFloat("WalkRight"), reletiveVelocity.x, Time.deltaTime * VelocitySmooth));
           // AnimatorModule.Animator.SetFloat("WalkForward", Mathf.Lerp(AnimatorModule.Animator.GetFloat("WalkForward"), reletiveVelocity.z, Time.deltaTime * VelocitySmooth));

            //RigidbodyMain.MovePosition(RigidbodyMain.transform.position + TargetVector3 * Time.deltaTime);



            
        }


        public void Rotate()
        {
            MainTransform.rotation = Quaternion.Lerp(MainTransform.rotation, Quaternion.AngleAxis(GetAngle(LookAtVector3), Vector3.up), Time.deltaTime * RotationSpeed);
            //MainTransform.LookAt(new Vector3(LookAtVector3.x,MainTransform.position.y,LookAtVector3.z));
        }
        public float GetAngle(Vector3 target)
        {
            Vector3 targetVector = (target - transform.position + transform.forward * 0.3f).normalized;
            float angle = -Vector2.SignedAngle(Vector2.up, new Vector2(targetVector.x, targetVector.z));
            return angle;
        }
    }
}
