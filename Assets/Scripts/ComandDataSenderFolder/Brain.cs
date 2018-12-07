﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;
using UnityEngine;

namespace Assets.Scripts.ComandDataSenderFolder
{
    public class Brain:MonoBehaviour
    {
        public FacadeHumanMono Facade;
        public MoveDataSender MoveDataSender=new MoveDataSender();

        void Update()
        {
            Vector3 v = Facade.gameObject.transform.position;

            if (Input.GetKey("w"))
            {
                v += Facade.gameObject.transform.forward;
                MoveDataSender.SendMoveComand(Facade, v);
            }


            //MoveDataSender.SendMoveComand(Facade,v);
        }
    }
}
