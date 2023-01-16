using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GameSettings : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    public float m_InitialHealth;
    
    [MenuItem("Window/UI Toolkit/GameSettings")]
    public static void ShowExample()
    {
        GameSettings wnd = GetWindow<GameSettings>();
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
    
    private void OnInspectorUpdate()
    {
        Debug.Log(m_InitialHealth);
    }
}
