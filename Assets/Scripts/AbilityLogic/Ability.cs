﻿using CameraLogic;
using Infrastructure.Factory.Pools;
using Plugins.MonoCache;
using Services.Inputs;

namespace AbilityLogic
{
    enum IndexAbility
    {
        Sword = 0,
        Grenade = 1,
        Ultimate = 2
    }

    public abstract class Ability : MonoCache
    {
        public abstract void Cast();
        public abstract int GetIndexAbility();
        public abstract void Construct(IInputService inputService, Pool pool, CameraFollow cameraFollow);
    }
}