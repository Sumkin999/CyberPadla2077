using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.StateFolder.StateHumFolder;
using UnityEngine;

namespace Assets.Scripts.HumanMonoModules
{
    public class StateController
    {
        public StateController(TransformModule transformModule, AnimatorModule animatorModule, PhysicsModule physicsModule)
        {
            TransformModule = transformModule;
            AnimatorModule = animatorModule;
            PhysicsModule = physicsModule;

        }
        public TransformModule TransformModule;
        public AnimatorModule AnimatorModule;
        public PhysicsModule PhysicsModule;


        private List<ComandDataBase> _dataToProcessList=new List<ComandDataBase>();

        public void AddToDataList(ComandDataBase comandData)
        {
            _dataToProcessList.Add(comandData);
        }

        public StateBase CurrentState;

        public void ProcessInputData()
        {

            foreach (var data in _dataToProcessList)
            {
                CurrentState.ProcessData(data);
            }

            foreach (var command in CurrentState.Commands)
            {
                command.UpdateCommand();
            }
        }
    }
}
