using System;
using Plugins.MonoCache;
using Services.Health;

namespace Enemies
{
    enum BossId
    {
        Bat,
        Dragon,
        EvilMage,
        Golem,
        MonsterPlant,
        Orc,
        Skeleton,
        Slime,
        Spider,
        TurtleShell
    }
    
    public abstract class Enemy : MonoCache, IHealth, ISwitcher
    {
        public void TakeDamage(int damage) {}
        
        public abstract int GetId();
        public void OnActive() {}
        public void InActive() {}
    }
}