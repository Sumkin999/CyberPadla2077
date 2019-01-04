﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.HumanMonoModules;
using UnityEngine;

namespace Assets.Scripts.ComandDataSenderFolder
{
    public class MoveDataSender
    {
        public void SendMoveComand(IFacade facadeI, Vector3 vec)
        {
            ComandDataMove cmm=new ComandDataMove();
            cmm.Vector3 = vec;

            cmm.IsMoveByPathFind = false;

            facadeI.ComandGet(cmm);
        }

        public void SendRunComand(IFacade facadeI)
        {
            ComandDataRun cmr=new ComandDataRun();

            facadeI.ComandGet(cmr);
        }
    }
}
