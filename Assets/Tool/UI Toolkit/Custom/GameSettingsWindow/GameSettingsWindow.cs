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
        _gameSettings.AsteroidSpawnerSettings.Sync();
    }
}
