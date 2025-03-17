using System;
using Unity.VisualScripting.Dependencies.Sqlite;


[Serializable]
public class Shrimp
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }

    public string Name { get; set; }

    public decimal Value { get; set; }
    
    public int TankID { get; set; }
    
    public bool IsFemale { get; set; }

    public bool Pregnant { get; set; }

    public int Health { get; set; }
    
    public float BaseValue { get; set; }
    
    public float Transparency { get; set; }
    
    public bool Bioluminescence { get; set; }
    
    public float Fertility { get; set; }
    
    public int GestationTime { get; set; }
    
    public int EggCount { get; set; }
    
    public float TemperatureTolerance { get; set; }
    
    public float PHTolerance { get; set; }
    
    
    // ENUMS
    [Ignore]
    public Grade Grade { get; set; }
    [Ignore]
    public Maturity Maturity { get; set; }
    [Ignore]
    public ActivityLevel ActivityLevel { get; set; }
    [Ignore]
    public Rarity Rarity { get; set; }
    [Ignore]
    public Size Size { get; set; }
    
    
    // ENUM References
    public int GradeInt { get; set; }
    public int MaturityInt { get; set; }
    public int ActivityLevelInt { get; set; }
    public int RarityInt { get; set; }
    public int SizeInt { get; set; }
    

    public void ReconcileEnums()
    {
        Grade = (Grade)GradeInt;
        Maturity = (Maturity)MaturityInt;
        ActivityLevel = (ActivityLevel)ActivityLevelInt;
        Rarity = (Rarity)RarityInt;
        Size = (Size)SizeInt;
    }

    public void ReconcileInts()
    {
        GradeInt = (int)Grade;
        MaturityInt = (int)Maturity;
        ActivityLevelInt = (int)ActivityLevel;
        RarityInt = (int)Rarity;
        SizeInt = (int)Size;
    }
    
    private Grade DetermineGrade(int value)
    {
        if (value >= 1000)
            return Grade.SSS; 
        else if (value >= 750) 
            return Grade.SS;
        else if (value >= 500)
            return Grade.S;
        else if (value >= 100)
            return Grade.A;
        else if (value >= 10)
            return Grade.B;
        else
            return Grade.C;
    }
    
}
