using UnityEditor;
using UnityEngine.UIElements;


[CustomEditor(typeof(GameSettings))]
public class GameSettingsEditor : Editor
{
    public VisualTreeAsset visualTreeAsset;

    public override VisualElement CreateInspectorGUI()
    {
        return visualTreeAsset.CloneTree();
    }
}
