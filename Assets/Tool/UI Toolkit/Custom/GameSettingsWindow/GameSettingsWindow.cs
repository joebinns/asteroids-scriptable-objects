using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class GameSettingsWindow : EditorWindow // TODO: OnEnable, instance the scriptable object
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
        //_gameSettings = AssetDatabase.LoadAssetAtPath<GameSettings>("Assets/Tools/Scriptable Objects/Instances/Game Settings.asset");
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
}
