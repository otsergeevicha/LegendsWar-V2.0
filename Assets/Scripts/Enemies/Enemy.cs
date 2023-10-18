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
    
    public abstract class Enemy : MonoCache, IHealth
    {
        public void TakeDamage(int damage) {}
        
        public abstract int GetId();
        public abstract void OnActive();
        public abstract void InActive();
    }
}