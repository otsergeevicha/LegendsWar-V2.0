public static class Constants
{
    //scenes
    public const string MainScene = "Main";
        
    //saveLoad
    public const string Progress = "Progress";
    
    //tower
    public const int TowerSize = 1;
    public const int CountSpawnBlocks = TowerSize;
    
    //path
    public const string BlockPath = "Blocks/Block";
    public const string PoolPath = "Pools/Pool";
    public const string MainPlatformPath = "Tower/MainPlatform";
    public const string TankPath = "Vehicle/Tank";
    public const string BulletPath = "Ammo/Bullet";
    public const string ObstacleHolderPath = "Obstacles/ObstacleHolder";
    public const string WindowRootPath = "Canvases/WindowRoot";
    public const string SoundOperatorPath = "SoundFX/SoundOperator";
    
    //tank
    public const int DelayShots = 100;
    
    //pool
    public const int CountSpawnBullets = 20;
    
    //bullet
    public const float BulletSpeed = 20f;
    public const int ExplosionForce = 100;
    public const int ExplosionRadius = 100;
    public const float CameraPositionY = 11f;
    
    //rotateObstacle
    public const float AnimationDuration = 3f;
    
    //Leaderboard
    public const string Leaderboard = "Leaderboard";
    public const string Anonymous = "Anonymous";
    public const int TopPlayersCount = 7;
    public const int CompletingPlayersCount = 1;
}