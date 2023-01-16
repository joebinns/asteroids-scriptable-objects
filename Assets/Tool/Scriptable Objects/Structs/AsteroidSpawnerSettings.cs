using UnityEngine;

public struct AsteroidSpawnerSettings
{
    public Vector2 SpawnTimeRange;
    public Vector2Int AmountRange;

    public AsteroidSpawnerSettings(Vector2 spawnTimeRange, Vector2Int amountRange)
    {
        this.SpawnTimeRange = spawnTimeRange;
        this.AmountRange = amountRange;
    }
}