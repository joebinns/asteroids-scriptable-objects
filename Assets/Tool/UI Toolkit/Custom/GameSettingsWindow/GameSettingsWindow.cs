using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GameSettingsWindow : EditorWindow // TODO: OnEnable, instance the scriptable object
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    [MenuItem("Window/UI Toolkit/GameSettings")]
    public static void ShowExample()
    {
        GameSettingsWindow wnd = GetWindow<GameSettingsWindow>();
        wnd.titleContent = new GUIContent("GameSettings");
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
