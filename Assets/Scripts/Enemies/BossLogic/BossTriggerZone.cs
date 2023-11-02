using System;
using HeroLogic;
using Plugins.MonoCache;
using UnityEngine;

namespace Enemies.BossLogic
{
    public class BossTriggerZone : MonoCache
    {
        public event Action EnterTriggered;
        public event Action ExitTriggered;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.TryGetComponent(out Hero _)) 
                EnterTriggered?.Invoke();
        }
        
        private void OnTriggerExit(Collider collision)
        {
            if (collision.TryGetComponent(out Hero _)) 
                ExitTriggered?.Invoke();
        }
    }
}