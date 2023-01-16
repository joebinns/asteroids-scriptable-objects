using System;

[Serializable]
public struct EngineSettings 
{
    public float ThrottlePower;
    public float RotationPower;

    public EngineSettings(float throttlePower, float rotationPower)
    {
        this.ThrottlePower = throttlePower;
        this.RotationPower = rotationPower;
    }
}