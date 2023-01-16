using Asteroids;
using Ship;
using UnityEngine;

public class GameSettingsApplication : MonoBehaviour
{
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private AsteroidSpawner _asteroidSpawner;
    [SerializeField] private Engine _engine;
    [SerializeField] private Hull _hull;
    [SerializeField] private Gun _gun;

    private void Start()
    {
        ApplyGameSettings();
    }

    private void ApplyGameSettings()
    {
        ApplyAsteroidSpawnerSettings();
        ApplyEngineSettings();
        ApplyHullSettings();
        ApplyGunSettings();
    }

    private void ApplyAsteroidSpawnerSettings()
    {
        _asteroidSpawner.MinSpawnTime = _gameSettings.AsteroidSpawnerSettings.SpawnTimeRange.x;
        _asteroidSpawner.MaxSpawnTime = _gameSettings.AsteroidSpawnerSettings.SpawnTimeRange.y;
        _asteroidSpawner.MinAmount = _gameSettings.AsteroidSpawnerSettings.AmountRange.x;
        _asteroidSpawner.MaxAmount = _gameSettings.AsteroidSpawnerSettings.AmountRange.y;
    }
    
    private void ApplyEngineSettings()
    {
        _engine.ThrottlePower = _gameSettings.EngineSettings.ThrottlePower;
        _engine.RotationPower = _gameSettings.EngineSettings.RotationPower;
    }

    private void ApplyHullSettings()
    {
        _hull.Health = _gameSettings.HullSettings.InitialHealth;
    }

    private void ApplyGunSettings()
    {
        _gun.Cooldown = _gameSettings.GunSettings.Cooldown;
    }
}

