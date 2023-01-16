using UnityEngine;

[CreateAssetMenu(menuName = "Tool/ScriptableObjects/GameSettings")]
public class GameSettings : ScriptableObject
{
    public AsteroidSpawnerSettings AsteroidSpawnerSettings;
    public HullSettings HullSettings;
    public EngineSettings EngineSettings;
    public GunSettings GunSettings;
}
