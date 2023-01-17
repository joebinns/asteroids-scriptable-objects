using System.Collections.Generic;
using Asteroids;
using Ship;
using UnityEngine;

// TODO: Assign a component type to each settings struct. (in struct).
// TODO: For each struct, get all instances of it's component type in the scene.
// TODO: For each instance of component type, set the components variables to be that of the struct. (as is already done)

public class GameSettingsApplication : MonoBehaviour
{
    [SerializeField] private GameSettings _gameSettings;

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
        foreach (var asteroidSpawner in GetAsteroidSpawners())
        {
            asteroidSpawner.MinSpawnTime = _gameSettings.AsteroidSpawnerSettings.SpawnTimeRange.x;
            asteroidSpawner.MaxSpawnTime = _gameSettings.AsteroidSpawnerSettings.SpawnTimeRange.y;
            asteroidSpawner.MinAmount = _gameSettings.AsteroidSpawnerSettings.AmountRange.x;
            asteroidSpawner.MaxAmount = _gameSettings.AsteroidSpawnerSettings.AmountRange.y;
        }
    }
    
    private void ApplyEngineSettings()
    {
        foreach (var engine in GetEngines())
        {
            engine.ThrottlePower = _gameSettings.EngineSettings.ThrottlePower;
            engine.RotationPower = _gameSettings.EngineSettings.RotationPower;
        }
    }

    private void ApplyHullSettings()
    {
        foreach (var hull in GetHulls())
        {
            hull.Health = _gameSettings.HullSettings.InitialHealth;
        }
    }

    private void ApplyGunSettings()
    {
        foreach (var gun in GetGuns())
        {
            gun.Cooldown = _gameSettings.GunSettings.Cooldown;
        }
    }
    
    private IEnumerable<AsteroidSpawner> GetAsteroidSpawners() => FindObjectsOfType<AsteroidSpawner>();
    private IEnumerable<Engine> GetEngines() => FindObjectsOfType<Engine>();
    private IEnumerable<Hull> GetHulls() => FindObjectsOfType<Hull>();
    private IEnumerable<Gun> GetGuns() => FindObjectsOfType<Gun>();
}

