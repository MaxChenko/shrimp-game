﻿using Unity.VisualScripting.Dependencies.Sqlite;

namespace Data
{
    public class Shrimp
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    
        public string Name { get; set; }
    
        public bool CanGetPregnant { get; set; }
        
    }
}