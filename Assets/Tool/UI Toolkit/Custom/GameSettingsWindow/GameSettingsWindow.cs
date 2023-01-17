using System.Collections.Generic;
using Asteroids;
using Ship;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class GameSettingsWindow : EditorWindow
{
    [SerializeField] private VisualTreeAsset m_VisualTreeAsset = default;
    [SerializeField] private GameSettings _gameSettings;

    [MenuItem("Window/UI Toolkit/GameSettings")]
    public static void ShowExample()
    {
        GameSettingsWindow wnd = GetWindow<GameSettingsWindow>();
        wnd.titleContent = new GUIContent("GameSettings");
    }

    private void OnEnable()
    {
        rootVisualElement.Bind(new SerializedObject(_gameSettings));
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Instantiate UXML
        VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
        root.Add(labelFromUXML);
    }

    private void OnInspectorUpdate()
    {
        _gameSettings.AsteroidSpawnerSettings.Sync(); // Ensure that min does not exceed max
    }


    /*
    public override void SaveChanges()
    {
        base.SaveChanges();
        ApplyGameSettings();
    }
    */

    private void OnLostFocus()
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
            var serializedObject = new SerializedObject(asteroidSpawner);
            serializedObject.FindProperty("MinSpawnTime").floatValue = _gameSettings.AsteroidSpawnerSettings.SpawnTimeRange.x;
            serializedObject.FindProperty("MaxSpawnTime").floatValue = _gameSettings.AsteroidSpawnerSettings.SpawnTimeRange.y;
            serializedObject.FindProperty("MinAmount").intValue = _gameSettings.AsteroidSpawnerSettings.AmountRange.x;
            serializedObject.FindProperty("MaxAmount").intValue = _gameSettings.AsteroidSpawnerSettings.AmountRange.y;
            serializedObject.ApplyModifiedProperties();
        }
    }
    
    private void ApplyEngineSettings()
    {
        foreach (var engine in GetEngines())
        {
            var serializedObject = new SerializedObject(engine);
            serializedObject.FindProperty("ThrottlePower").floatValue = _gameSettings.EngineSettings.ThrottlePower;
            serializedObject.FindProperty("RotationPower").floatValue = _gameSettings.EngineSettings.RotationPower;
            serializedObject.ApplyModifiedProperties();
        }
    }

    private void ApplyHullSettings()
    {
        foreach (var hull in GetHulls())
        {
            var serializedObject = new SerializedObject(hull);
            serializedObject.FindProperty("Health").intValue = _gameSettings.HullSettings.InitialHealth;
            serializedObject.ApplyModifiedProperties();
        }
    }

    private void ApplyGunSettings()
    {
        foreach (var gun in GetGuns())
        {
            var serializedObject = new SerializedObject(gun);
            serializedObject.FindProperty("Cooldown").floatValue = _gameSettings.GunSettings.Cooldown;
            serializedObject.ApplyModifiedProperties();
        }
    }
    
    private IEnumerable<AsteroidSpawner> GetAsteroidSpawners() => FindObjectsOfType<AsteroidSpawner>();
    private IEnumerable<Engine> GetEngines() => FindObjectsOfType<Engine>();
    private IEnumerable<Hull> GetHulls() => FindObjectsOfType<Hull>();
    private IEnumerable<Gun> GetGuns() => FindObjectsOfType<Gun>();
}
