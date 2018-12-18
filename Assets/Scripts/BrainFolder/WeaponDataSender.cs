using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.HumanMonoModules;

namespace Assets.Scripts.BrainFolder
{
    public class WeaponDataSender
    {
        public void SelectNextWeaponComand(IFacade facadeI, bool forward)
        {
            ComandDataSelectWeapon cmm = new ComandDataSelectWeapon();
            cmm.IsForward = forward;

            facadeI.ComandGet(cmm);
        }

        public void Attack(IFacade facadeI, bool prim, bool secondary)
        {
            ComandDataAim cma=new ComandDataAim();
            cma.IsPrimaryPressed = prim;
            cma.IsSecondaryPressed = secondary;

            facadeI.ComandGet(cma);
        }
    }
}
