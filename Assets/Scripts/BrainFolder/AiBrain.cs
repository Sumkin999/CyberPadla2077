using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.BrainFolder.InteractionDataSenderFolder;
using Assets.Scripts.ComandDataSenderFolder;
using Assets.Scripts.HumanMonoModules;
using UnityEngine;

namespace Assets.Scripts.BrainFolder
{
    public class AiBrain:MonoBehaviour
    {
        public FacadeHumanMono Facade;
        public MoveDataSender MoveDataSender = new MoveDataSender();
        public WeaponDataSender WeaponDataSender = new WeaponDataSender();
        public RotateDataSender RotateDataSender = new RotateDataSender();
        public FallDataSender FallDataSender = new FallDataSender();

        




        private Vector3 _lookDirVector3;


        private float _betweenTimer;
        private float _goTimer=2f;
        private int _f=1;
        private int _s=1;

        void Update()
        {
            
            
            if (_goTimer > 0)
            {
                _goTimer -= Time.deltaTime;

                MoveFunction(_f,_s);
            }
            else
            {
                if (_betweenTimer < 0)
                {
                    _betweenTimer = 2f;
                }
            }

            if (_betweenTimer > 0)
            {
                _betweenTimer -= Time.deltaTime;
            }
            else
            {
                if (_goTimer < 0)
                {
                    _f = (int)UnityEngine.Random.Range(-10.5f, 10.5f);
                    _s = (int)UnityEngine.Random.Range(-10.5f, 10.5f);

                    _goTimer = 2f;
                }
            }
        }

        private void MoveFunction(int frw,int side)
        {
            Vector3 v = Vector3.zero;

            if (frw>0)
            {
                v += Vector3.forward * 5f;
            }
            else
            {
                if (frw<0)
                {
                    v -= Vector3.forward * 5f;
                }
            }
            if (side>0)
            {
                v += Vector3.right * 5f;
            }
            else
            {
                if (side<0)
                {
                    v -= Vector3.right * 5f;
                }
            }
            if (v.sqrMagnitude > 0)
            {
                v += Facade.gameObject.transform.position;
                MoveDataSender.SendMoveComand(Facade, v);
            }
        }
    }
}
