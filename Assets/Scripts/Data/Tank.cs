using Unity.VisualScripting.Dependencies.Sqlite;


public class Tank
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }

    public string Name { get; set; }
    
    public int Capacity { get; set;  }
    
    public int ActualCapacity { get; set; }
}
