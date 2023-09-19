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
        private Hero _hero;
        public void Construct(IInputService input, Pool pool, CameraFollow cameraFollow, Hero hero = null)
        {
            _hero = hero;
            input.PushShoot(OnShoot);
         //   _abilitySelector.Construct(input, pool, cameraFollow);
        }
        
        private void OnShoot()
        {
            _hero.TakeDamage(40);
            //            TryGetAbility().Cast();
        }
        

        private Ability TryGetAbility() =>
            _abilitySelector.GetAbilities().FirstOrDefault(ability =>
                ability.isActiveAndEnabled);
    }
}