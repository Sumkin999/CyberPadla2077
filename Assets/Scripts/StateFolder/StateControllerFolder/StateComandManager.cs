using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ComandFolder.ComandData;
using Assets.Scripts.ComandFolder.Commands;
using Assets.Scripts.HumanMonoModules;

namespace Assets.Scripts.StateFolder.StateControllerFolder
{
    public class StateComandManager
    {
        private StateController _stateController;
        public List<Command> AllCommands=new List<Command>();
        public StateComandManager(StateController stateController)
        {
            _stateController = stateController;

            AllCommands.Add(new CommandMove());
            AllCommands.Add(new ComandRotate());
            AllCommands.Add(new ComandAim());
            AllCommands.Add(new ComandAttack());
            AllCommands.Add(new ComandSelectWeapon());
            AllCommands.Add(new ComandFall());

            foreach (var comand in AllCommands)
            {
                comand.StateController = _stateController;
            }

        }
    }
}
