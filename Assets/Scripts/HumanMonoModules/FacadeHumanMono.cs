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
    class FacadeHumanMono:MonoBehaviour,IFacade
    {
        public TransformModule TransformModule;
        public PhysicsModule PhysicsModule;
        public AnimatorModule AnimatorModule;

        public ComandCreator ComandCreator;

        private StateController _stateController;

        

        public void ComandGet(ComandDataBase comandData) 
        {
            _stateController.AddToDataList(comandData);

        }

        void Start()
        {
            _stateController=new StateController(TransformModule,AnimatorModule,PhysicsModule);

            _stateController.CurrentState=new StateIdle(_stateController);
            

            ComandCreator.ThisFacade = this;

            
        }

        void Update()
        {
            ComandCreator.MoveComandCreate(Vector3.forward);

           // _stateController=new StateController(TransformModule,AnimatorModule,PhysicsModule);
            
            _stateController.ProcessInputData();
        }
    }
}
