using System;

[Serializable]
public struct GunSettings
{
    public float Cooldown;

    public GunSettings(float cooldown)
    {
        this.Cooldown = cooldown;
    }
}