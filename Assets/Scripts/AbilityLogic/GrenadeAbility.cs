using System;
using AbilityLogic.Catridges;
using Ammo.Ammunition;
using CameraLogic;
using Infrastructure.Factory.Pools;
using Services.Inputs;
using UnityEngine;

namespace AbilityLogic
{
    public class GrenadeAbility : Ability
    {
        [SerializeField] private Transform _spawnPointGrenade;

        private readonly float _ourGravity = Physics.gravity.y;

        private float _axisX;
        private float _axisY;

        private Pool _pool;
        private Camera _camera;
        private MagazineGrenade _magazine;
        private Animator _animator;

        public override int GetIndexAbility() =>
            (int)IndexAbility.Grenade;

        public override void Construct(IInputService inputService, Pool pool, CameraFollow cameraFollow,
            Animator animator)
        {
            _animator = animator;
            _pool = pool;
            _camera = cameraFollow.GetCameraMain();
            _magazine = new MagazineGrenade(Constants.GrenadeMagazineSize);
        }

        public override void Cast()
        {
            if (_magazine.Check()) 
                _animator.SetTrigger(Constants.CastGrenadeHash);
        }

        public void Throw()
        {
            Ray ray = SendRay();
                
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                Vector3 fromTo = raycastHit.point - transform.position;
                Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

                _axisX = fromToXZ.magnitude;
                _axisY = fromTo.y;

                float angleInRadians = Constants.AngleInDegrees * MathF.PI / 180;
                float rootOfSpeed = (_ourGravity * _axisX * _axisX) /
                                    (2 * (_axisY - Mathf.Tan(angleInRadians) * _axisX) *
                                     Mathf.Pow(Mathf.Cos(angleInRadians), 2));
                float speed = Mathf.Sqrt(Mathf.Abs(rootOfSpeed));

                Grenade grenade = _pool.TryGetGrenade();
                grenade.gameObject.SetActive(true);
                grenade.transform.position = _spawnPointGrenade.position;
                grenade.transform.LookAt(raycastHit.point);
                grenade.Throw(raycastHit.point * speed * 4 * Time.deltaTime);

                _magazine.Spend();
            }

            _magazine.Shortage();
        }

        private Ray SendRay() =>
            _camera.ScreenPointToRay(GetCenter());

        private Vector2 GetCenter() =>
            new(Screen.width / 2f, Screen.height / 2f);
    }
}