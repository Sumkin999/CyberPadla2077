﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.HumanMonoModules;

namespace Assets.Scripts.ComandFolder.ComandData
{
    public interface INeedDataToContinue
    {
        bool IsProdlena { get;  set; }
        void Prodlit();
        void UnProdlit();
    }
    public class Command
    {
        public StateController StateController;

        public virtual void GetInputData(ComandDataBase comandData)
        {
            
        }
        public virtual bool StartConditionCheck()
        {
            return true;
        }

        public bool Iniciated;
        public void StartCommando()
        {

            
            if (StartConditionCheck())
            {
                Iniciated = true;

                PrepareCommandoAction();
            }

        }
        public virtual void PrepareCommandoAction()
        {

        }
        public virtual void ExecuteAction()
        {

        }
        public virtual bool ContinueCommandoCheck()
        {
            return false;
        }

        public virtual void BreakCommandoAction()
        {

        }
        public void UpdateCommand()
        {
            if (Iniciated)
            {

                ExecuteAction();

                Iniciated = ContinueCommandoCheck();

                INeedDataToContinue ineed = this as INeedDataToContinue;
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
                }
                if (!Iniciated)
                {
                    BreakCommandoAction();
                }
                
            }
        }
    }
}
