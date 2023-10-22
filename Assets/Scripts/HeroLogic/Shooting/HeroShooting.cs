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
        [SerializeField] private GrenadeAbility _grenadeAbility;
        
        private Hero _hero;
        private int _currentIndexAbility = (int)IndexAbility.Sword;

        public void Construct(IInputService input, Pool pool, CameraFollow cameraFollow, Animator animator, Hero hero)
        {
            _hero = hero;
            input.PushShoot(OnShoot);
            _abilitySelector.Construct(input, pool, cameraFollow, animator, hero);

            _abilitySelector.AbilityChanged += SetCurrentAbility;
        }
        
        protected override void OnDisabled() => 
            _abilitySelector.AbilityChanged -= SetCurrentAbility;

        public int GetIndexAbility() => 
            _currentIndexAbility;

        private void OnShoot() => 
            TryGetAbility().Cast();

        private void Throw() =>
            _grenadeAbility.Throw();
        
        private Ability TryGetAbility() =>
            _abilitySelector.GetAbilities()
                .FirstOrDefault(ability => ability.isActiveAndEnabled);

        private void SetCurrentAbility(int newIndex) => 
            _currentIndexAbility = newIndex;
    }
}