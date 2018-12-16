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

        private Vector3 _lookDirVector3;

        public GameObject TargetTEMP;
        public Camera CameraMain;
        void Update()
        {
            CameraMain.gameObject.transform.position = new Vector3(Facade.gameObject.transform.position.x,CameraMain.gameObject.transform.position.y, Facade.gameObject.transform.position.z-10f); 
            Vector3 v = Vector3.zero;// Facade.gameObject.transform.position;

            if (Input.GetKey("w"))
            {
                //v +=  Facade.gameObject.transform .forward* 5f;
                v += Vector3.forward * 5f;
                //MoveDataSender.SendMoveComand(Facade, v);
            }
            else
            {
                if (Input.GetKey("s"))
                {
                    //v -= Facade.gameObject.transform.forward * 5f;
                    v-=Vector3.forward*5f;
                }
            }
            if (Input.GetKey("d"))
            {
                //v += Facade.gameObject.transform.right * 5f;
                v+=Vector3.right*5f;
                //MoveDataSender.SendMoveComand(Facade, v);
            }
            else
            {
                if (Input.GetKey("a"))
                {
                    //v -= Facade.gameObject.transform.right * 5f;
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



            Ray ray = CameraMain.ScreenPointToRay(Input.mousePosition);
            float dist = Mathf.Sqrt(ray.direction.y * ray.direction.y + CameraMain.transform.position.y * CameraMain.transform.position.y);
            _lookDirVector3 = ray.GetPoint(dist);
            _lookDirVector3.y = 0;
            Facade.TransformModule.LookAtVector3 = _lookDirVector3;


            ////!!!!!!!!!!!! TODO DELETE!!!!!!!!!
            Facade.TransformModule.Rotate();

            if (Input.GetKeyDown("f"))
            {
                Debug.Log("Force!");
                Facade.TransformModule.RigidbodyMain.AddForce(Vector3.forward*200f,ForceMode.Impulse);
                
            }

            //MoveDataSender.SendMoveComand(Facade,v);
        }
    }
}
