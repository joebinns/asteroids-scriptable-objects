using System;

[Serializable]
public struct HullSettings
{
    public int InitialHealth;

    public HullSettings(int initialHealth)
    {
        this.InitialHealth = initialHealth;
    }
}