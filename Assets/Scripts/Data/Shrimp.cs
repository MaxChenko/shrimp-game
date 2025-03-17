using System;
using Unity.VisualScripting.Dependencies.Sqlite;


[Serializable]
public class Shrimp
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }

    public string Name { get; set; }
    
    public int TankID { get; set; }

    public bool CanGetPregnant { get; set; }
    
}
