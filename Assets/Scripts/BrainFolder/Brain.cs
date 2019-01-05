using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.BrainFolder;
using Assets.Scripts.HumanMonoModules;
using UnityEngine;

namespace Assets.Scripts.ComandDataSenderFolder
{
    public class Brain:MonoBehaviour
    {
        public FacadeHumanMono Facade;
        public MoveDataSender MoveDataSender=new MoveDataSender();
        public WeaponDataSender WeaponDataSender=new WeaponDataSender();
        public RotateDataSender RotateDataSender=new RotateDataSender();
        public FallDataSender FallDataSender=new FallDataSender();

        private Vector3 _lookDirVector3;

        public GameObject TargetTEMP;
        public Camera CameraMain;
        void Update()
        {
            CameraMain.gameObject.transform.position = new Vector3(Facade.gameObject.transform.position.x,CameraMain.gameObject.transform.position.y, Facade.gameObject.transform.position.z-10f); 
            Vector3 v = Vector3.zero;

            if (Input.GetKey("w"))
            {
                v += Vector3.forward * 5f;
            }
            else
            {
                if (Input.GetKey("s"))
                {
                    v-=Vector3.forward*5f;
                }
            }
            if (Input.GetKey("d"))
            {
                v+=Vector3.right*5f;
            }
            else
            {
                if (Input.GetKey("a"))
                {
                    v-=Vector3.right*5f;
                }
            }
            if (v.sqrMagnitude>0)
            {
                v += Facade.gameObject.transform.position;
                MoveDataSender.SendMoveComand(Facade, v);
            }









            if (Input.GetKeyDown("k"))
            {

                WeaponDataSender.SelectNextWeaponComand(Facade,true);
            }
            if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
            {
                bool b0 = false;
                bool b1 = false;
                if (Input.GetMouseButton(0))
                {
                    b0 = true;
                }
                if (Input.GetMouseButton(1))
                {
                    b1 = true;
                }
                WeaponDataSender.Attack(Facade,b0,b1);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                
                MoveDataSender.SendRunComand(Facade);
            }


            Ray ray = CameraMain.ScreenPointToRay(Input.mousePosition);       
            Vector3 vVertical=new Vector3(ray.origin.x,0, ray.origin.z)- ray.origin;
            float angleBetweenVertical = Vector3.Angle(vVertical, ray.direction);
            float cosBetweenVertical= Mathf.Cos(angleBetweenVertical * Mathf.PI / 180);
            float dist = vVertical.magnitude/cosBetweenVertical;
            _lookDirVector3 = ray.GetPoint(dist);

            //TargetTEMP.transform.position = _lookDirVector3;



            RotateDataSender.SendRotateComand(Facade,_lookDirVector3);

            if (Input.GetKeyDown("f"))
            {
                //Debug.Log("Fall!");
                //Facade.TransformModule.RigidbodyMain.AddForce(Vector3.forward*200f,ForceMode.Impulse);
                FallDataSender.SendFallComand(Facade,Facade.PhysicsModule.HumanRagdoll.HipsTransform.GetComponent<Rigidbody>());
            }

            if (Input.GetKeyDown("q"))
            {
                MoveDataSender.SendMovePathFindComand(Facade,TargetTEMP.transform);
            }
            if (Input.GetKeyDown("n"))
            {
                MoveDataSender.SendMovePathFindComand(Facade, TargetTEMP.transform.position);
            }

            //MoveDataSender.SendMoveComand(Facade,v);
        }
    }
}
