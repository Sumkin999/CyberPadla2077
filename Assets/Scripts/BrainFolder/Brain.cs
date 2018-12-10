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
            Vector3 v = Facade.gameObject.transform.position;

            if (Input.GetKey("w"))
            {
                v = TargetTEMP.gameObject.transform.position;
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
