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
    public abstract class Command
    {
        

        public StateController StateController;

        //public bool IsNeededProdlenie { get; protected set; }
        //public bool IsProdlena { get; set; }

        protected virtual bool GetInputData(ComandDataBase comandData)
        {
            return false;
        }
        public void GetInputDataAndStart(ComandDataBase comandData)
        {
            if(GetInputData(comandData))
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

                //IsProdlena = true;
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

        protected virtual void AfterUpdateAction()
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

                /*if (IsNeededProdlenie)
                {
                    if (!IsProdlena)
                    {
                        Iniciated = false;
                    }
                    else
                    {
                        IsProdlena=false;
                    }
                }*/
                AfterUpdateAction();

                if (!Iniciated)
                {
                    BreakCommandoAction();
                }

                
                
            }
        }
    }
}
