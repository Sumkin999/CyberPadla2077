﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;

namespace Assets.Scripts.ComandFolder.ComandData
{
    /*public interface INeedDataToContinue
    {
        bool IsProdlena { get;  set; }
        void Prodlit();
        void UnProdlit();
    }*/
    public class Command
    {
        public StateController StateController;

        public bool IsNeededProdlenie { get; protected set; }
        public bool IsProdlena { get; set; }

        public virtual void GetInputData(ComandDataBase comandData)
        {
            
        }
        protected virtual bool StartConditionCheck()
        {
            return true;
        }

        public bool Iniciated { get; private set; }
        public void StartCommando()
        {

            
            if (StartConditionCheck())
            {
                Iniciated = true;

                PrepareCommandoAction();
            }

        }
        protected virtual void PrepareCommandoAction()
        {

        }
        protected virtual void ExecuteAction()
        {

        }
        protected virtual bool ContinueCommandoCheck()
        {
            return false;
        }

        protected virtual void BreakCommandoAction()
        {

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
                /*INeedDataToContinue ineed = this as INeedDataToContinue;
                if (ineed != null)
                {
                    if (!ineed.IsProdlena)
                    {
                        Iniciated = false;
                    }
                    else
                    {
                        ineed.UnProdlit();
                    }
                }*/
                if (!Iniciated)
                {
                    BreakCommandoAction();
                }
                
            }
        }
    }
}
