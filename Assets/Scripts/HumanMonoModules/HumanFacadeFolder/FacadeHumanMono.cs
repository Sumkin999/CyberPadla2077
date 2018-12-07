using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.StateFolder.StateHumFolder;
using UnityEngine;

namespace Assets.Scripts.HumanMonoModules
{
    public interface IFacade
    {
        
        void ComandGet(ComandDataBase comandData) ;
    }
    public class FacadeHumanMono:MonoBehaviour,IFacade
    {
        public TransformModule TransformModule;
        public PhysicsModule PhysicsModule;
        public AnimatorModule AnimatorModule;

        

        private StateController _stateController;

        

        public void ComandGet(ComandDataBase comandData) 
        {
            _stateController.CurrentState.AddCommandData(comandData);

        }

        void Start()
        {
            _stateController=new StateController(this,TransformModule,AnimatorModule,PhysicsModule);



            
        }

        void Update()
        {
           _stateController.StateControllerUpdateAction();
        }
    }
}
