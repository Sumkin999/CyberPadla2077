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

        public GameObject TargetTEMP;
        void Update()
        {
            Vector3 v = Vector3.zero;// Facade.gameObject.transform.position;

            if (Input.GetKey("w"))
            {
                v +=  Facade.gameObject.transform .forward* 5f;
                //MoveDataSender.SendMoveComand(Facade, v);
            }
            else
            {
                if (Input.GetKey("s"))
                {
                    v -= Facade.gameObject.transform.forward * 5f;
                    
                }
            }
            if (Input.GetKey("d"))
            {
                v += Facade.gameObject.transform.right * 5f;
                //MoveDataSender.SendMoveComand(Facade, v);
            }
            else
            {
                if (Input.GetKey("a"))
                {
                    v -= Facade.gameObject.transform.right * 5f;

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


            //MoveDataSender.SendMoveComand(Facade,v);
        }
    }
}
