using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.WeaponsFolder.ConcreteWeaponsFolder.WeaponMonoFolder
{
    public class WeaponPistolMono:WeaponMonoVisuals
    {
        public GameObject PistolGameObject;
        public ParticleSystem MuzzleParticleSystem;

        private float _muzzleTimer;
        public void ShowMuzzle()
        {
            MuzzleParticleSystem.Play();
            _muzzleTimer = .25f;
        }

        void Update()
        {
            _muzzleTimer -= Time.deltaTime;
            if (_muzzleTimer<=0)
            {
                if (MuzzleParticleSystem.isPlaying)
                {
                    MuzzleParticleSystem.Stop();
                }
            }
        }
    }
}
