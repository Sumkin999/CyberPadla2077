using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;

namespace Assets.Scripts.ComandFolder.ComandData
{
    /*
    Базовый класс КОМАНДЫ
    
        GetInputDataAndStart- старт команды/получение данных
        Если выполнен StartConditionCheck, то иницирована и выполняется Update/FixedUpdate
        IsProdlena-BreakComando в том числе если не получила обновления входящих данных
    */
    public class Command
    {
        public StateController StateController;

        public bool IsNeededProdlenie { get; protected set; }
        public bool IsProdlena { get; set; }

        protected virtual void GetInputData(ComandDataBase comandData)
        {
            
        }
        public void GetInputDataAndStart(ComandDataBase comandData)
        {
            GetInputData(comandData);
            StartCommando();
        }
        protected virtual bool StartConditionCheck()
        {
            return true;
        }

        public bool Iniciated { get; private set; }

        public void UnIniciate()
        {
            Iniciated = false;
        }
        private void StartCommando()
        {

            
            if (StartConditionCheck())
            {
                Iniciated = true;

                PrepareCommandoAction();

                IsProdlena = true;
            }

        }
        protected virtual void PrepareCommandoAction()
        {

        }
        protected virtual void ExecuteAction()
        {

        }

        protected virtual void FixedExecuteAction()
        {
            
        }
        protected virtual bool ContinueCommandoCheck()
        {
            return false;
        }

        protected virtual void BreakCommandoAction()
        {

        }

        public void FixedUpdateCommand()
        {
            if (Iniciated)
            {
                FixedExecuteAction();
            }
        }
        public void UpdateCommand()
        {
            if (Iniciated)
            {

                ExecuteAction();

                Iniciated = ContinueCommandoCheck();

                if (IsNeededProdlenie)
                {
                    if (!IsProdlena)
                    {
                        Iniciated = false;
                    }
                    else
                    {
                        IsProdlena=false;
                    }
                }
                
                if (!Iniciated)
                {
                    BreakCommandoAction();
                }
                
            }
        }
    }
}
