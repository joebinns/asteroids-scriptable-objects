using UnityEngine;

[CreateAssetMenu(menuName = "Tool/ScriptableObjects/AsteroidSpawnerSettings")]
public class AsteroidSpawnerSettings : ScriptableObject
{
    public Vector2 SpawnTimeRange = new Vector2(1f, 4f);
    public Vector2Int AmountRange = new Vector2Int(1, 2);
}