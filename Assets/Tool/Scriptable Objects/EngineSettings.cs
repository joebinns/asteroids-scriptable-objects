using UnityEngine;

[CreateAssetMenu(menuName = "Tool/ScriptableObjects/EngineSettings")]
public class EngineSettings : ScriptableObject
{
    public float ThrottlePower = 2f;
    public float RotationPower = 5f;
}