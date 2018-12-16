using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandDataSenderFolder;
using UnityEngine;

namespace Assets.Scripts.BrainFolder
{
    public class TestBrain:MonoBehaviour
    {
        public Rigidbody RbRigidbody;
        private Vector3 v;
        public void Update()
        {
            v = Vector3.zero;

            if (Input.GetKey("w"))
            {
                v += Vector3.forward * 5f;
            }
            else
            {
                if (Input.GetKey("s"))
                {
                    v -= Vector3.forward * 5f;
                }
            }
            if (Input.GetKey("d"))
            {
                v += Vector3.right * 5f;
            }
            else
            {
                if (Input.GetKey("a"))
                {
                    v -= Vector3.right * 5f;
                }
            }
            
        }

        void FixedUpdate()
        {
            v.Normalize();
            if (v.sqrMagnitude > 0)
            {
                //RbRigidbody.AddForce(RbRigidbody.gameObject.transform.position + v  * 10f);
                RbRigidbody.MovePosition(RbRigidbody.gameObject.transform.position + v * Time.deltaTime *1f);
            }
            if (Input.GetKeyDown("g"))
            {
                Vector3 vv=RbRigidbody.gameObject.transform.right;
                //MainTransform.rotation = Quaternion.Lerp(MainTransform.rotation, Quaternion.AngleAxis(GetAngle(LookAtVector3), Vector3.up), Time.deltaTime * RotationSpeed);
                RbRigidbody.MoveRotation(Quaternion.Lerp(RbRigidbody.gameObject.transform.rotation, Quaternion.AngleAxis(GetAngle(vv), Vector3.up), Time.deltaTime * 180));
            }

           // Vector3 v2 = Physics.gravity * RbRigidbody.mass;
           // RbRigidbody.AddForce(-v2);
        }
        public float GetAngle(Vector3 target)
        {
            Vector3 targetVector = (target - transform.position + transform.forward * 0.3f).normalized;
            float angle = -Vector2.SignedAngle(Vector2.up, new Vector2(targetVector.x, targetVector.z));
            return angle;
        }
    }
}
