using System.Linq;
using Ammo.Ammunition;
using Enemies.BossLogic;
using HeroLogic;
using Plugins.MonoCache;
using Services.Factory;

namespace Infrastructure.Factory.Pools
{
    public class Pool : MonoCache
    {
        private GrenadePool _grenadePool;
        private BossPool _bossPool;
        
        private IGameFactory _factory;

        public void Construct(IGameFactory factory, Hero hero)
        {
            _factory = factory;
            
            _grenadePool = new GrenadePool(_factory);
            _bossPool = new BossPool(_factory, hero);
        }

        public Grenade TryGetGrenade() =>
            _grenadePool.GetGrenades().FirstOrDefault(grenade =>
                grenade.isActiveAndEnabled == false);
        
        public Boss TryGetBoss(int idBoss) =>
        _bossPool.GetBoss().FirstOrDefault(boss =>
            boss.GetId() == idBoss);
    }
}