using System.Linq;
using Ammo.Ammunition;
using Plugins.MonoCache;
using Services.Factory;

namespace Infrastructure.Factory.Pools
{
    public class Pool : MonoCache
    {
        private GrenadePool _grenadePool;
        private ArrowPool _arrowPool;
        private IGameFactory _factory;

        public void Construct(IGameFactory factory)
        {
            _factory = factory;
            
            _grenadePool = new GrenadePool(_factory);
            _arrowPool = new ArrowPool(_factory);
        }

        public Arrow TryGetArrow() =>
            _arrowPool.GetArrows().FirstOrDefault(arrow =>
                arrow.isActiveAndEnabled == false);

        public Grenade TryGetGrenade() =>
            _grenadePool.GetGrenades().FirstOrDefault(grenade =>
                grenade.isActiveAndEnabled == false);
    }
}