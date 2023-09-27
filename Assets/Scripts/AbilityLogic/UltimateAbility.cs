using CameraLogic;
using Cysharp.Threading.Tasks;
using Infrastructure.Factory.Pools;
using Services.Inputs;
using UnityEngine;

namespace AbilityLogic
{
    public class UltimateAbility : Ability
    {
        [SerializeField] private ParticleSystem _particleUltimateSword;

        private Animator _animator;

        public override int GetIndexAbility() =>
            (int)IndexAbility.Ultimate;

        public override void Construct(IInputService inputService, Pool pool, CameraFollow cameraFollow,
            Animator animator)
        {
            _animator = animator;
        }

        public override void Cast()
        {
            _particleUltimateSword.gameObject.SetActive(false);
            _particleUltimateSword.gameObject.SetActive(true);
            
            _animator.SetTrigger(Constants.UltimateHash);
            LaunchEffect().Forget();
        }

        private async UniTaskVoid LaunchEffect()
        {
            await UniTask.Delay(480);
            _particleUltimateSword.Play();
        }
    }
}