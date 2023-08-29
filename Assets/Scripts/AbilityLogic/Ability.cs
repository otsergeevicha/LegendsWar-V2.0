using CameraLogic;
using Infrastructure.Factory.Pools;
using Plugins.MonoCache;
using Services.Inputs;

namespace AbilityLogic
{
    enum IndexAbility
    {
        Arch = 0,
        Sword = 1,
        Grenade = 2,
        Ultimate = 3
    }

    public abstract class Ability : MonoCache
    {
        public abstract void Cast();
        public abstract int GetIndexAbility();
        public abstract void Construct(IInputService inputService, Pool pool, CameraFollow cameraFollow);
    }
}