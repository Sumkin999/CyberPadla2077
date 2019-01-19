using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.BrainFolder.InteractionDataSenderFolder;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.HumanMonoModules.HumanInteractionFolder;
using Assets.Scripts.StateFolder.StateHumFolder;
using Assets.Scripts.StateFolder.StateTreeFolder.ScrObjStateTreeFolder;
using Assets.Scripts.WeaponsFolder;
using UnityEngine;

namespace Assets.Scripts.HumanMonoModules
{
    /*
    Главный класс Хумана 
         
         Модули-модули управления различными аспектами
         
         IFacade-интерфейс для взаимодействия с другим сущностями
         
         
         
         
    */
    public interface IFacade
    {
        
        void ComandGet(ComandDataBase comandData) ;
    }
    public class FacadeHumanMono:MonoBehaviour,IFacade
    {
        public TransformModule TransformModule;
        public PhysicsModule PhysicsModule;
        public AnimatorModule AnimatorModule;
        public WeaponModule WeaponModule;


        public ScrObjStateTree ScrObjStateTree;
        private StateController _stateController;


        
        public List<ColliderHumanPart> ColliderHumanParts=new List<ColliderHumanPart>();






        public void ComandGet(ComandDataBase comandData) 
        {
            if (_stateController == null)
            {
                return;
            }
            if (_stateController.CurrentState==null)
            {
                return;
            }
            _stateController.CurrentState.AddCommandData(comandData);

        }

        void Start()
        {
            _stateController=new StateController(this,TransformModule,AnimatorModule,PhysicsModule,WeaponModule);
           

            ScrObjStateTree.InicateTree(_stateController);

            //_stateController.CurrentState = _stateController.StateTree.SetIdleStateAsCurrent();

            WeaponModule.SetFacade(this);


            WeaponModule.IniciateWeaponModule();
            AnimatorModule.IniciateAnimatorModule(this);
            PhysicsModule.InicPhysicModule(this);


            foreach (var coll in ColliderHumanParts)
            {
                coll.IfFacade = this;
            }
        }

        void Update()
        {
            if (_stateController==null)
            {
                return;
            }
           _stateController.StateControllerUpdateAction();


            
            
        }

        void FixedUpdate()
        {
            if (_stateController == null)
            {
                return;
            }
            _stateController.StateControllerFixedUpdateAction();
        }
    }
}
