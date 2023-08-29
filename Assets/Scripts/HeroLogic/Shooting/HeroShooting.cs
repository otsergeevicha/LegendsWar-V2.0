using System.Linq;
using AbilityLogic;
using CameraLogic;
using Infrastructure.Factory.Pools;
using Plugins.MonoCache;
using Services.Inputs;
using UnityEngine;

namespace HeroLogic.Shooting
{
    public class HeroShooting : MonoCache
    {
        [SerializeField] private AbilitySelector _abilitySelector;

        public void Construct(IInputService input, Pool pool, CameraFollow cameraFollow)
        {
            input.PushShoot(OnShoot);
            _abilitySelector.Construct(input, pool, cameraFollow);
        }

        private void OnShoot() =>
            TryGetAbility().Cast();

        private Ability TryGetAbility() =>
            _abilitySelector.GetAbilities().FirstOrDefault(ability =>
                ability.isActiveAndEnabled);
    }
}