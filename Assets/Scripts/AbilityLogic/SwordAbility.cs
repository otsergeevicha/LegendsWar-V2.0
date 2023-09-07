using CameraLogic;
using Infrastructure.Factory.Pools;
using Services.Inputs;

namespace AbilityLogic
{
    public class SwordAbility : Ability
    {
        public override void Construct(IInputService inputService, Pool pool, CameraFollow cameraFollow)
        {
            throw new System.NotImplementedException();
        }

        public override int GetIndexAbility() =>
            (int)IndexAbility.Sword;

        public override void Cast()
        {
            throw new System.NotImplementedException();
        }
    }
}