using UnityEngine;

public class DebugGameSettings : MonoBehaviour
{
    [SerializeField] private GameSettings _gameSettings;

    private void Update()
    {
        Debug.Log(_gameSettings.AsteroidSpawnerSettings.SpawnTimeRange);
        //Debug.Log(_gameSettings.HullSettings.InitialHealth);
    }
}

