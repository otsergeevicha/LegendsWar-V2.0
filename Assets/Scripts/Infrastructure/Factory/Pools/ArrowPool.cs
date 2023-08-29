using Ammo.Ammunition;
using Services.Factory;

namespace Infrastructure.Factory.Pools
{
    public class ArrowPool
    {
        private readonly Arrow[] _arrows = new Arrow[Constants.CountSpawnArrows];
    
        public ArrowPool(IGameFactory factory)
        {
            for (int i = 0; i < _arrows.Length; i++)
            {
                _arrows[i] = factory.CreateArrow();
                _arrows[i].gameObject.SetActive(false);
            }
        }

        public Arrow[] GetArrows() =>
            _arrows;
    }
}