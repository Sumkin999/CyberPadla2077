using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.ComandFolder.ComandData.InteractionComandDataFolder;
using UnityEngine;

namespace Assets.Scripts.ComandFolder.Commands.CommandsInteraction
{
    public class ComandInShotted: Command
    {
        protected override bool GetInputData(ComandDataBase comandData)
        {
            ComandInDataShotted comandDataShotted = comandData as ComandInDataShotted;
            if (comandDataShotted != null)
            {
                Debug.Log(StateController.TransformModule.gameObject.name+" Shotted!");
                //StateController.WeaponModule.SetPressedFlags(comandDataShotted.IsPrimaryPressed, comandDataAim.IsSecondaryPressed);


                return true;
                //StartCommando();
            }

            return false;
        }
    }
}
