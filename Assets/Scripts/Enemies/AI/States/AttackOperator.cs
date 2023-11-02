using Enemies.BossLogic;
using HeroLogic;
using Plugins.MonoCache;
using UnityEngine;

namespace Enemies.AI.States
{
    [RequireComponent(typeof(Boss))]
    public class AttackOperator : MonoCache, IBossAttacker
    {
        [HideInInspector] [SerializeField] private Boss _boss;
        
        private Collider[] _overlappedColliders = new Collider[30];

        private void OnValidate() => 
            _boss = Get<Boss>();

        public void Attacked()
        {
            _overlappedColliders = Physics.OverlapSphere(_boss.SpawnPointAttack, _boss.RadiusAttack);
            
            for (int i = 0; i < _overlappedColliders.Length; i++)
            {
                if (_overlappedColliders[i].gameObject.TryGetComponent(out Hero hero))
                    hero.TakeDamage(_boss.DamageAttack);
            }
        }

        public void StartAoeAttacked() {}

        public void EndAoeAttacked() {}
    }
}