using System;
using CameraLogic;
using Infrastructure.Factory.Pools;
using Plugins.MonoCache;
using Services.Inputs;
using UnityEngine;

namespace AbilityLogic
{
    public class AbilitySelector : MonoCache
    {
        [SerializeField] private Ability[] _abilities;

        public event Action<int> AbilityChanged;
        
        private IInputService _input;

        public void Construct(IInputService input, Pool pool, CameraFollow cameraFollow, Animator animator)
        {
             _input = input;
            
            for (int i = 0; i < _abilities.Length; i++) 
                _abilities[i].Construct(_input, pool, cameraFollow, animator);
            
            SelectAbility((int)IndexAbility.Sword);
            
            _input.PushSword(() =>
                SelectAbility((int)IndexAbility.Sword));
            _input.PushGrenade(() =>
                SelectAbility((int)IndexAbility.Grenade));
            _input.PushUltimate(() =>
                SelectAbility((int)IndexAbility.Ultimate));
        }

        public void SelectAbility(int selectIndexAbility)
        {
            for (int i = 0; i < _abilities.Length; i++)
                _abilities[i].gameObject.SetActive(_abilities[i].GetIndexAbility() == selectIndexAbility);
            
            AbilityChanged?.Invoke(selectIndexAbility);
        }

        public Ability[] GetAbilities() => 
            _abilities;
    }
}