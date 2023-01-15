using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class DragAndDropWindow : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    [MenuItem("Window/UI Toolkit/Drag And Drop")]
    public static void ShowExample()
    {
        DragAndDropWindow wnd = GetWindow<DragAndDropWindow>();
        wnd.titleContent = new GUIContent("Drag And Drop");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Instantiate UXML
        VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
        root.Add(labelFromUXML);
        
        // Instantiate Drag And Drop Manipulator
        DragAndDropManipulator manipulator = new(rootVisualElement.Q<VisualElement>("object"));
    }
}
