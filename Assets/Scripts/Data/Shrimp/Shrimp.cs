using System;
using Unity.VisualScripting.Dependencies.Sqlite;


[Serializable]
public class Shrimp
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; }

    public string Name { get; set; }

    public decimal Value { get; set; }
    
    public Grade Grade { get; }
    
    public Maturity Maturity { get; set; }
    
    public bool IsFemale { get; }
    
    public bool Pregnant { get; set; }
    
    public int Health { get; set; }
    
    public Species Species { get; }
    
    
    private Grade DetermineGrade()
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
