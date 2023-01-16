using System;
using UnityEngine;

[Serializable]
public struct AsteroidSpawnerSettings
{
    public Vector2 SpawnTimeRange;
    public Vector2Int AmountRange;

    public AsteroidSpawnerSettings(Vector2 spawnTimeRange, Vector2Int amountRange)
    {
        SpawnTimeRange = spawnTimeRange;
        AmountRange = amountRange;
    }

    public void Sync()
    {
        if (SpawnTimeRange.x > SpawnTimeRange.y)
        {
            SpawnTimeRange.y = SpawnTimeRange.x;
        }
        
        if (AmountRange.x > AmountRange.y)
        {
            AmountRange.y = AmountRange.x;
        }
    }
}