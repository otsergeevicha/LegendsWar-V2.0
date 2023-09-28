using AbilityLogic.Catridges;
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
        private MagazineUltimate _magazine;

        public override int GetIndexAbility() =>
            (int)IndexAbility.Ultimate;

        public override void Construct(IInputService inputService, Pool pool, CameraFollow cameraFollow,
            Animator animator)
        {
            _animator = animator;
            _magazine = new MagazineUltimate(Constants.UltimateMagazineSize);
        }

        public override void Cast()
        {
            if (_magazine.Check())
            {
                _particleUltimateSword.gameObject.SetActive(false);
                _particleUltimateSword.gameObject.SetActive(true);
            
                _animator.SetTrigger(Constants.UltimateHash);
                LaunchEffect().Forget();
                
                _magazine.Spend();
            }
                
            _magazine.Shortage();
        }

        private async UniTaskVoid LaunchEffect()
        {
            await UniTask.Delay(480);
            _particleUltimateSword.Play();
        }
    }
}