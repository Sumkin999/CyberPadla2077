using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;
using UnityEngine;

namespace Assets.Scripts.ComandFolder.ComandData
{
    public interface IComandCreator
    {
        void ComandCreate(ComandDataBase comandData,IFacade targetFacade) ;
    }
    public class ComandCreator:MonoBehaviour,IComandCreator
    {
        public void ComandCreate(ComandDataBase comandData,IFacade targetFacade)
        {
            
            targetFacade.ComandGet(comandData);
        }

        public IFacade ThisFacade;

        public void MoveComandCreate(Vector3 v)
        {
            ComandDataMove cmm=new ComandDataMove();
            cmm.Vector3 = v;

            ComandCreate(cmm,ThisFacade);
        }
    }
}
