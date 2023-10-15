using System;
using Enemies;
using Plugins.MonoCache;
using UnityEngine;

namespace Ammo.Ammunition
{
    [RequireComponent(typeof(Rigidbody))]
    public class Grenade : MonoCache
    {
        [SerializeField] private Transform _explosionEffect;
        [SerializeField] private Rigidbody _rigidbody;
        
        private Collider[] _overlappedColliders = new Collider[30];

        public void Throw(Vector3 forward) => 
            _rigidbody.velocity = forward;

        private void OnValidate() => 
            _rigidbody = Get<Rigidbody>();

        private void OnTriggerEnter(Collider _)
        {
            _overlappedColliders = Physics.OverlapSphere(transform.position, Constants.RadiusExplosion);
        
            for (int i = 0; i < _overlappedColliders.Length; i++)
            {
                if (_overlappedColliders[i].gameObject.TryGetComponent(out Enemy enemy))
                    enemy.TakeDamage(Constants.GrenadeDamage);
        
                if (_overlappedColliders[i].gameObject.TryGetComponent(out Rigidbody touchedExplosion))
                    touchedExplosion.AddExplosionForce(Constants.ForceExplosion, transform.position, Constants.RadiusExplosion);
            }
        
            Instantiate(_explosionEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}