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

        private IInputService _input;

        public void Construct(IInputService input, Pool pool, CameraFollow cameraFollow)
        {
             _input = input;
            
            for (int i = 0; i < _abilities.Length; i++) 
                _abilities[i].Construct(_input, pool, cameraFollow);
            
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
        }

        public Ability[] GetAbilities() => 
            _abilities;
    }
}