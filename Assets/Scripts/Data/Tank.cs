using System;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

[Serializable]
public class Tank
{
    [Ignore]
    public GameObject GameObject { get; set; }
    
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }

    public string Name { get; set; }
    
    public int Capacity { get; set;  }
    
    public int ActualCapacity { get; set; }
    
    public String Slot { get; set; }
}
