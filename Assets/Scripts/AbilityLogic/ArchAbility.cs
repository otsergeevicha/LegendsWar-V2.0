using System.Threading;
using AbilityLogic.Catridges;
using CameraLogic;
using Cysharp.Threading.Tasks;
using Infrastructure.Factory.Pools;
using Services.Inputs;
using UnityEngine;

namespace AbilityLogic
{
    public class ArchAbility : Ability
    {
        [SerializeField] private Vector3 _spawnPoint;

        private readonly CancellationTokenSource _shootToken = new();

        private Pool _pool;
        private Camera _camera;
        private bool _isAttack;
        private MagazineArch _magazine;

        public override void Construct(IInputService inputService, Pool pool, CameraFollow cameraFollow)
        {
            IInputService input = inputService;
            input.OffShoot(OffShoot);
            _magazine = new MagazineArch(Constants.FirearmsMagazineSize);
        }

        public override int GetIndexAbility() =>
            (int)IndexAbility.Arch;
    

        public void Inject(Pool pool, CameraFollow cameraFollow)
        {
            _pool = pool;
            _camera = cameraFollow.GetCameraMain();
        }

        public override void Cast()
        {
            _isAttack = true;
            _ = ImitationQueue();
        }

        private void OffShoot()
        {
            _isAttack = false;
            _shootToken.Cancel();
        }

        private async UniTaskVoid ImitationQueue()
        {
            while (_isAttack)
            {
                if (Physics.Raycast(SendRay(), out RaycastHit hit))
                {
                    if (_magazine.Check())
                    {
                        _pool.TryGetArrow().Shot(_spawnPoint, hit.point);
                        _magazine.Spend();
                    }

                    _magazine.Shortage();
                }

                await UniTask.Delay(Constants.DelayShots);
            }
        }

        private Ray SendRay() =>
            _camera.ScreenPointToRay(GetCenter());

        private Vector2 GetCenter() =>
            new(Screen.width / 2f, Screen.height / 2f);
    }
}