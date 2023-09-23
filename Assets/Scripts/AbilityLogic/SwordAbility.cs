using CameraLogic;
using Infrastructure.Factory.Pools;
using Services.Inputs;
using UnityEngine;

namespace AbilityLogic
{
    enum CombinationStage
    {
        OutwardSlash,
        InwardSlash,
        SwordCombo
    }

    public class SwordAbility : Ability
    {
        private Animator _animator;
        private int _currentCombination = (int)CombinationStage.OutwardSlash;

        public override void Construct(IInputService inputService, Pool pool, CameraFollow cameraFollow,
            Animator animator)
        {
            _animator = animator;
        }

        public override int GetIndexAbility() =>
            (int)IndexAbility.Sword;

        public override void Cast() =>
            _animator.SetTrigger(CurrentCombination());

        private string CurrentCombination()
        {
            return _currentCombination switch
            {
                (int)CombinationStage.OutwardSlash =>
                    CombinationStage.OutwardSlash.ToString(),
                (int)CombinationStage.InwardSlash =>
                    CombinationStage.InwardSlash.ToString(),
                (int)CombinationStage.SwordCombo =>
                    CombinationStage.SwordCombo.ToString(),
                _ => CombinationStage.OutwardSlash.ToString()
            };
        }
    }
    
    public class ComboAttackModule
    {
    }
}