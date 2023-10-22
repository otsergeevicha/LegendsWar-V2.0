using AbilityLogic.Catridges;
using CameraLogic;
using Cysharp.Threading.Tasks;
using Enemies;
using HeroLogic;
using Infrastructure.Factory.Pools;
using Services.Inputs;
using UnityEngine;

namespace AbilityLogic
{
    public class UltimateAbility : Ability
    {
        [SerializeField] private ParticleSystem _particleUltimateSword;
        
        [SerializeField] private Transform _firstPoint;
        [SerializeField] private Transform _secondPoint;

        private Animator _animator;
        private MagazineUltimate _magazine;
        
        private Collider[] _overlappedColliders = new Collider[30];
        private Hero _hero;

        public override int GetIndexAbility() =>
            (int)IndexAbility.Ultimate;

        public override void Construct(IInputService inputService, Pool pool, CameraFollow cameraFollow,
            Animator animator, Hero hero)
        {
            _hero = hero;
            _animator = animator;
            _magazine = new MagazineUltimate(Constants.UltimateMagazineSize);
            
            _hero.SwordAnimationHited += CheckEnemies;
        }
        
        protected override void OnDisabled() => 
            _hero.SwordAnimationHited -= CheckEnemies;

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
        
        private void CheckEnemies()
        {
            Vector3 firstPointsCapsule = _firstPoint.position;
            Vector3 secondPointCapsule = _secondPoint.position;
            
            _overlappedColliders = Physics.OverlapCapsule(firstPointsCapsule, secondPointCapsule, Constants.RadiusSword);

            for (int i = 0; i < _overlappedColliders.Length; i++)
            {
                if (_overlappedColliders[i].gameObject.TryGetComponent(out Enemy enemy))
                    enemy.TakeDamage(Constants.SwordUltimateDamage);
            }
        }

        private async UniTaskVoid LaunchEffect()
        {
            await UniTask.Delay(480);
            _particleUltimateSword.Play();
        }
    }
}