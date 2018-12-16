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
        public float MoveSpeed;

        public Vector3 LookAtVector3;

        public float VelocitySmooth = 10;
        public float RotationSpeed = 180f;

        private Vector3 _localTarget;
        private Vector3 _lastPosition;
        private float _timerLastPosition;
        public void Move()
        {
            _localTarget = TargetVector3;
            if (PathFindIsOn)
            {
                
            }
            else
            {
                
            }
            
            RigidbodyMain.MovePosition(MainTransform.position + _localTarget.normalized * Time.deltaTime * MoveSpeed);

            //_lastPosition = MainTransform.position;

            
        }

        public void MoveAnimationControl()
        {
            
            if (_timerLastPosition<=0)
            {
                
                _lastPosition = MainTransform.position;
                _timerLastPosition = 0.2f;
            }

            Vector3 reletiveVelocity = _lastPosition - MainTransform.position;// _localTarget - MainTransform.position;
            reletiveVelocity.Normalize();
            reletiveVelocity = MainTransform.InverseTransformVector(-reletiveVelocity);
            _timerLastPosition -= Time.deltaTime;


            AnimatorModule.SetWalkBlendDirection(reletiveVelocity, VelocitySmooth);
        }


        public void Rotate()
        {
            MainTransform.rotation = Quaternion.Lerp(MainTransform.rotation, Quaternion.AngleAxis(GetAngle(LookAtVector3), Vector3.up), Time.deltaTime * RotationSpeed);
            //MainTransform.LookAt(new Vector3(LookAtVector3.x,MainTransform.position.y,LookAtVector3.z));
        }
        private float GetAngle(Vector3 target)
        {
            Vector3 targetVector = (target - transform.position + transform.forward * 0.3f).normalized;
            float angle = -Vector2.SignedAngle(Vector2.up, new Vector2(targetVector.x, targetVector.z));
            return angle;
        }
    }
}
