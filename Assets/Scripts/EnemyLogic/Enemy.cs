using System;
using Plugins.MonoCache;
using Services.Health;

namespace EnemyLogic
{
    public class Enemy : MonoCache, IHealth
    {
        public void TakeDamage(int damage)
        {
            throw new NotImplementedException();
        }
    }
}