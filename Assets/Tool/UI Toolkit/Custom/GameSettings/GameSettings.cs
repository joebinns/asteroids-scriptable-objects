using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class GameSettings : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

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
        
        //OnSelectionChange(); // TODO: I don't think this is the binding I wanted... Why is it talking about game objects?
    }
    
    /*
    public void OnSelectionChange()
    {
        GameObject selectedObject = Selection.activeObject as GameObject;
        if (selectedObject != null)
        {
            // Create serialization object
            SerializedObject so = new SerializedObject(selectedObject);
            // Bind it to the root of the hierarchy. It will find the right object to bind to...
            rootVisualElement.Bind(so);
        }
        else
        {
            // Unbind the object from the actual visual element
            rootVisualElement.Unbind();
              
            // Clear the TextField after the binding is removed
            // (this code is not safe if the Q() returns null)
            rootVisualElement.Q<Foldout>("engine").Q<VisualElement>("unity-content").Q<Slider>("throttle-power").value = 0;
            //rootVisualElement.Q<Slider>("Throttle Power").value = 0;
        }
    }
    */

    private void OnValidate()
    {
        //Debug.Log(rootVisualElement.Q<Slider>("Throttle Power").value);
    }
}
