using System;
using HeroLogic;
using Plugins.MonoCache;
using UnityEngine;

namespace Enemies.BossLogic
{
    public class BossTriggerZone : MonoCache
    {
        public event Action Triggered;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.TryGetComponent(out Hero _)) 
                Triggered?.Invoke();
        }
    }
}