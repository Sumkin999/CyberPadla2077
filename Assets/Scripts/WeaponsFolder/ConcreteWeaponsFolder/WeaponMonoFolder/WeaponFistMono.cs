using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.WeaponsFolder.ConcreteWeaponsFolder.WeaponMonoFolder
{
    public class WeaponFistMono:MonoBehaviour
    {
        public Collider Collider;
        public MeshRenderer MeshRenderer;

        public float TimerActive;

        void Update()
        {
            if (TimerActive > -1)
                TimerActive -= Time.deltaTime;

            if (TimerActive <= 0)
            {
                MeshRenderer.material.color=Color.grey;
            }
        }
        public void ActivateCollider()
        {
            MeshRenderer.material.color = Color.red;
            TimerActive = 1.5f;
        }

        public void DeactivateHit()
        {
            Debug.Log("NO HIT");
            MeshRenderer.material.color = Color.grey;
            TimerActive = 0;
        }
    }
}
