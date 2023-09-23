using CameraLogic;
using Infrastructure.Factory.Pools;
using Services.Inputs;
using UnityEngine;

namespace AbilityLogic
{
    public class UltimateAbility : Ability
    {

        public override int GetIndexAbility() =>
            (int)IndexAbility.Ultimate;

        public override void Construct(IInputService inputService, Pool pool, CameraFollow cameraFollow, Animator animator) {}

        public override void Cast() {}
    }
}