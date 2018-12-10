using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.StateFolder.StateHumFolder;
using Assets.Scripts.StateFolder.StateTreeFolder.ScrObjStateTreeFolder;
using Assets.Scripts.WeaponsFolder;
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
        public WeaponModule WeaponModule;


        public ScrObjStateTree ScrObjStateTree;
        private StateController _stateController;

        

        public void ComandGet(ComandDataBase comandData) 
        {
            _stateController.CurrentState.AddCommandData(comandData);

        }

        void Start()
        {
            _stateController=new StateController(this,TransformModule,AnimatorModule,PhysicsModule,WeaponModule);

            ScrObjStateTree.InicateTree(_stateController);

            WeaponModule.SetFacade(this);


            WeaponModule.SpawnWeapon<WeaponFist>();
            WeaponModule.SpawnWeapon<WeaponPistol>();
            WeaponModule.CurrentWeapon = WeaponModule.InventoryWeapon[0];
            WeaponModule.CurrentWeapon.WeaponSelectedAction();
            //WeaponPistol pistol=new WeaponPistol(WeaponModule.);
        }

        void Update()
        {
           _stateController.StateControllerUpdateAction();


            if (Input.GetKeyDown("a"))
            {
                AnimatorModule.Animator.SetBool("IsAiming",!AnimatorModule.Animator.GetBool("IsAiming"));
            }
            
            
        }
    }
}
