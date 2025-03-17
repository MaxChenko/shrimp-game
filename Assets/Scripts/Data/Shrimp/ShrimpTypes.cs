public enum Grade
{
    SSS,
    SS,
    S,
    A,
    B,
    C
}

public enum Maturity
{
    Larva,
    Juvenile,
    Adult
}

public enum ActivityLevel
{
    Low,
    Medium,
    High
}

public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}

public enum Size
{
    Tiny,
    Small,
    Medium,
    Large
}

public class Species
{
    decimal BaseValue { get; }
    Rarity Rarity { get; }
    Size Size { get; }
    float Transparency { get; }
    bool Bioluminescence { get; }
    float Fertility { get; }
    int GestationTime { get; }
    int EggCount { get; }
    ActivityLevel ActivityLevel { get; }
    float MinTemperatureTolerance { get; }
    float MaxTemperatureTolerance { get; }
    float MinPHTolerance { get; }
    float MaxPHTolerance { get; }
    
    // WaterType WaterType { get; }
    // Food[] Diet { get; }
}
