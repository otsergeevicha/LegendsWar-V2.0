﻿using UnityEngine;

public static class Constants
{
    //saveLoad
    public const string Progress = "Progress";

    //paths
    public const string PoolPath = "Pools/Pool";
    public const string MainScene = "Main";
    public const string HeroPath = "Player/Hero";
    public const string WindowRootPath = "Canvases/WindowRoot";
    public const string CameraPath = "Camera/MainCamera";
    public const string GrenadePath = "Ammo/Grenade";
    public const string EnemySpawnerPath = "Spawner/EnemySpawner";
    
    public const string BatPath = "Bosses/Bat";
    public const string DragonPath = "Bosses/Dragon";
    public const string EvilMagePath = "Bosses/EvilMage";
    public const string GolemPath = "Bosses/Golem";
    public const string MonsterPlantPath = "Bosses/MonsterPlant";
    public const string OrcPath = "Bosses/Orc";
    public const string SkeletonPath = "Bosses/Skeleton";
    public const string SlimePath = "Bosses/Slime";
    public const string SpiderPath = "Bosses/Spider";
    public const string TurtleShellPath = "Bosses/TurtleShell";

    //hero
    public const int HeroMaxHealth = 100;
    public const int HeroSpeed = 4;
    
    //animator hero
    public static readonly int HeroSwordRunHash = Animator.StringToHash("SwordRun");
    public static readonly int HeroWithoutSwordRunHash = Animator.StringToHash("WithoutSwordRun");
    
    public static readonly int OutwardSlashHash = Animator.StringToHash("OutwardSlash");
    public static readonly int InwardSlashHash = Animator.StringToHash("InwardSlash");
    public static readonly int SwordComboHash = Animator.StringToHash("SwordCombo");
    
    public static readonly int UltimateHash = Animator.StringToHash("Ultimate");
    public static readonly int CastGrenadeHash = Animator.StringToHash("CastGrenade");

    //bosses
    public const int CooldownAgroBoss = 3500;
    
    public const float MinDistance = 1f;
    public const float MaxDistance = 2f;
    public const float PursuitDistance = 5f;
    public const float MaxRangePursuit = 10f;
    public const int TimeConditionsPersecution = 500;
    
    //animator bosses
    public static readonly int IdleStateHash = Animator.StringToHash("IdleState");
    public static readonly int MeleeAttackStateHash = Animator.StringToHash("MeleeAttackState");
    public static readonly int EnragedAttackStateHash = Animator.StringToHash("EnragedAttackState");
    public static readonly int BossWalkHash = Animator.StringToHash("BossWalk");
    public static readonly int BossDieHash = Animator.StringToHash("Die");
    public static readonly int BossGetHitHash = Animator.StringToHash("GetHit");
    
    //regeneration
    public const float DelayRegeneration = .5f;
    public const int DelayRegenerationMagazine = 5000;

    //sword
    public const float RadiusSword = 1f;
    public const int SwordDamage = 15;
    public const int SwordUltimateDamage = 150;

    //grenade
    public const float RadiusExplosion = 10f;
    public const float ForceExplosion = 500f;
    public const float AngleInDegrees = 45f;
    public const int GrenadeDamage = 50;
    public const int GrenadeMagazineSize = 5;
    
    //ultimate
    public const int UltimateMagazineSize = 1;

    //pool
    public const int CountSpawnGrenade = 5;

    //check device
    public const string KeyboardMouse = "KeyboardMouse";
}