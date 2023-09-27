using UnityEngine;

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
    public const string ArrowPath = "Ammo/Arrow";

    //hero
    public const int HeroMaxHealth = 100;
    public const int HeroSpeed = 4;
    
    //animator hero
    public static readonly int HeroSwordRunHash = Animator.StringToHash("SwordRun");
    public static readonly int HeroWithoutSwordRunHash = Animator.StringToHash("WithoutSwordRun");
    
    public static readonly int OutwardSlashHash = Animator.StringToHash("OutwardSlash");
    public static readonly int InwardSlashHash = Animator.StringToHash("InwardSlash");
    public static readonly int SwordComboHash = Animator.StringToHash("SwordCombo");
    
    //regeneration
    public const float DelayRegeneration = .5f;
    public const int DelayRegenerationMagazine = 5000;

    //Firearms
    public const int DelayShots = 100;
    public const int FirearmsMagazineSize = 20;

    //grenade
    public const float RadiusExplosion = 10f;
    public const float ForceExplosion = 500f;
    public const float AngleInDegrees = 45f;
    public const int GrenadeDamage = 50;
    public const int GrenadeMagazineSize = 1;

    //bullet
    public const int BulletDamage = 50;
    public const float BulletSpeed = 20f;

    //pool
    public const int CountSpawnGrenade = 20;
    public const int CountSpawnArrows = 150;

    //check device
    public const string KeyboardMouse = "KeyboardMouse";
}